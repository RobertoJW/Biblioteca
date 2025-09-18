using MySqlConnector;

namespace Biblioteca;

// esta clase la usaremos para conectarnos a la base de datos de MySQL
public class Conector
{
    // cadena de conexion con la base de datos, aqui tienes que insertar tus datos correspondientes 
    private readonly string connMySQL = "Server=localhost;Database=biblioteca;User ID=root;Password=1234";

    public async Task<bool> ProbarConexionAsync()
    {
        try
        {
            using var connection = new MySqlConnection(connMySQL);
            await connection.OpenAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("No se ha podido conectar a la base de datos: " + e.Message);
            return false; 
        }
    }
}