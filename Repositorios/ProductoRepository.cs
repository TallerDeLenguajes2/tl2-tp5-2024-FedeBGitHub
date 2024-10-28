using models;
using  Microsoft.Data.Sqlite;

namespace repositorys;

public class ProductoRepository
{
    const string cadenaConexion = @"Data Source=db/Tienda.db;Cache=Shared"; // si le borro el Cache=Shared funca igual
    /*
    ● Crear un nuevo Producto. (recibe un objeto Producto) --- listo
    ● Modificar un Producto existente. (recibe un Id y un objeto Producto)
    ● Listar todos los Productos registrados. (devuelve un List de Producto) --- listo
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

    public void modificarProducto(int id, Producto prod)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @idProd;";
            connection.Open();
            SqliteCommand command = new SqliteCommand(query,connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion",prod.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio",prod.Precio));
            command.Parameters.Add(new SqliteParameter("@idProd",id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Producto> listarProductos()
    {
        List<Producto> LProductos = new List<Producto>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = "SELECT * FROM Productos";
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["idProducto"]);
                    string descripcion = Convert.ToString(reader["Descripcion"]);
                    int precio;
                    int.TryParse(reader["Precio"].ToString(), out precio); //otra forma de conversion de datos usando TryParse funciona tambien para float y es lo que usaba en TallerI
                    LProductos.Add(new Producto (id,descripcion,precio));
                }
            }
            connection.Close();
        }
        return LProductos;
    }

/*
    private static void GetEmpleados(string connectionString)
    {
        string queryString = "SELECT Nombre, IDEmpleado FROM dbo.Empleado;";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",reader[0], reader[1]));
                }
            }
            connection.Close();
        }
    }
*/
}