namespace models;
public class PresupuestoDetalle
{
    private Producto producto;
    private int cantidad;

    
    public int Cantidad { get => cantidad;}
    public Producto Producto { get => producto; }

    void cargarProducto(Producto p)
    {
        this.producto = p;
    }
}