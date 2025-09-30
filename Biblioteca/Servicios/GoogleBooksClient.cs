using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Biblioteca.Modelo;
using System.Text.Json;
using System.Diagnostics;

namespace Biblioteca.Servicios
{

    // esta clase sirve para consultar a la API de Google Books
    public class GoogleBooksClient
    {
        private static readonly HttpClient _http = new HttpClient();
        private const string _baseUrl = "https://www.googleapis.com/books/v1/volumes?q=";

        public async Task<RespuestaLibros?> FetchPageAsync(string query, int startIndex = 0, int maxResult = 40, string? apiKey = null)
        {
            if (maxResult <= 0) maxResult = 10;
            if (maxResult > 40) maxResult = 40;

            var q = Uri.EscapeDataString(query);
            string url = $"{_baseUrl}{q}&startIndex={startIndex}&maxResults={maxResult}";

            if (!string.IsNullOrEmpty(apiKey))
                url += $"&key={apiKey}";

            return await _http.GetFromJsonAsync<RespuestaLibros>(url);

        }

        public async Task<List<Libro>> CargarLibrosPopulares()
        {
            string urlPopulares = "https://www.googleapis.com/books/v1/volumes?q=subject:fiction&orderBy=relevance&maxResults=20";
            var respuesta = await _http.GetStringAsync(urlPopulares);
            
            var resultado = JsonSerializer.Deserialize<RespuestaLibros>(respuesta);

            return resultado.Libros.Select(Libros => new Libro
            {
                Titulo = Libros.Informacion.Titulo,
                Autor = Libros.Informacion.Autores.FirstOrDefault() ?? "Desconocido",
                Editorial = Libros.Informacion.Editorial ?? "Desconocido",
                Portada = Libros.Informacion.Imagenes?.Portada.Replace("http://", "https://") ??
                "https://via.placeholder.com/150x200?text=No+Image",
                Rating = Libros.Informacion.Rating ?? 0
                
            }).ToList() ?? new List<Libro>();
        }

        public async Task<List<Libro>> CargarLibrosNuevos()
        {
            string url = "https://www.googleapis.com/books/v1/volumes?q=book&orderBy=newest&maxResults=20";
            var respuesta = await _http.GetStringAsync(url);
            var resultado = JsonSerializer.Deserialize<RespuestaLibros>(respuesta);

            return resultado.Libros.Select(l => new Libro
            {
                Titulo = l.Informacion.Titulo,
                Autor = l.Informacion.Autores.FirstOrDefault() ?? "Desconocido",
                Editorial = l.Informacion.Editorial ?? "Desconocido",
                Portada = l.Informacion.Imagenes?.Portada.Replace("http://", "https://") ??
                "https://via.placeholder.com/150x200?text=No+Image",
                Rating = l.Informacion.Rating ?? 0

            }).ToList() ?? new List<Libro>();
        }

        public async Task<List<Libro>> CargarLibrosMasVendidos()
        {
            string url = "https://www.googleapis.com/books/v1/volumes?q=bestseller&maxResults=20";
            var respuesta = await _http.GetStringAsync(url);

            var resultado = JsonSerializer.Deserialize<RespuestaLibros>(respuesta);

            return resultado.Libros.Select(Libros => new Libro
            {
                Titulo = Libros.Informacion.Titulo,
                Autor = Libros.Informacion.Autores.FirstOrDefault() ?? "Desconocido",
                Editorial = Libros.Informacion.Editorial ?? "Desconocido",
                Portada = Libros.Informacion.Imagenes?.Portada.Replace("http://", "https://") ??
                "https://via.placeholder.com/150x200?text=No+Image",
                Rating = Libros.Informacion.Rating ?? 0

            }).ToList() ?? new List<Libro>();
        }

        /*
        public async Task<List<ItemLibro>> FetchManyAsync(string query, int desiredCount = 200, string? apiKey = null)
        {
            var client = new GoogleBooksClient();
            var all = new List<ItemLibro>();
            int start = 0;
            int pageSize = 40; // máximo por petición

            while (all.Count < desiredCount)
            {
                var resp = await client.FetchPageAsync(query, start, pageSize, apiKey);
                if (resp?.Items == null || resp.Items.Count == 0) break;

                all.AddRange(resp.Items);

                // si totalItems nos dice que ya no hay más, salimos
                if (resp.TotalItems <= all.Count) break;

                start += pageSize;

                // opcional: pequeña espera para evitar burst y respetar límites
                await Task.Delay(150);
            }

            // recorta al tamaño pedido si hace falta
            if (all.Count > desiredCount) all = all.GetRange(0, desiredCount);
            return all;
        }
        */

    }
}
