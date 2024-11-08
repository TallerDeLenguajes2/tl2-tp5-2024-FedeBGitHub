namespace models;
public class Presupuesto
{
    private int idPresupuesto;
    private string nombreDestinatario;

    private DateTime fechaCreacion;
    private List<PresupuestoDetalle> detalle;

    public int IdPresupuesto { get => idPresupuesto;}
    public string NombreDestinatario { get => nombreDestinatario;}
    public DateTime FechaCreacion { get => fechaCreacion;}
    public List<PresupuestoDetalle> Detalle { get => detalle;}

    public Presupuesto(int idPresupuesto, string nombreDestinatario, DateTime fechaCreacion)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinatario = nombreDestinatario;
        this.fechaCreacion = fechaCreacion;
        this.detalle = new List<PresupuestoDetalle>();
    }

    public float MontoPresupuesto()
    {
        float monto = 0;
        foreach (PresupuestoDetalle pd in Detalle)
        {
            monto = monto + (pd.Producto.Precio * pd.Cantidad);
        }
        
        return monto;
    }

    public double montoPresupuestoConIva()
    {
        return (MontoPresupuesto() * 1.21);
    }

    public int cantidadProductos()
    {
        return Detalle.Count;
    }
    
    public void agregarDetalle(PresupuestoDetalle detalle)
    {
        this.detalle.Add(detalle);
    }
}