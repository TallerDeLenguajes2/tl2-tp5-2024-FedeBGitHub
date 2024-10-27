using models;
using  Microsoft.Data.Sqlite;

namespace repositorys;

public class ProductoRepository
{
    const string cadenaConexion = @"db/Tienda.db";
    /*
    ● Crear un nuevo Producto. (recibe un objeto Producto)
    ● Modificar un Producto existente. (recibe un Id y un objeto Producto)
    ● Listar todos los Productos registrados. (devuelve un List de Producto)
    ● Obtener detalles de un Productos por su ID. (recibe un Id y devuelve un Producto)
    ● Eliminar un Producto por ID
    */
    public void CrearProducto(Producto producto)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
        
    }

}