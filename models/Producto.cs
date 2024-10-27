namespace models;
public class Producto 
{
    private int idProducto;
    private string descripcion;
    private int precio;

    public Producto(int idProducto, string descripcion, int precio)
    {
        this.idProducto = idProducto;
        this.descripcion = descripcion;
        this.precio = precio;
    }

    public int Precio { get => precio;}
    public string Descripcion { get => descripcion; }
}


