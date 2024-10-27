namespace models;
public class Presupuesto
{
    private int idPresupuesto;
    private string nombreDestinatario;

    private DateTime fechaCreacion;
    private List<PresupuestoDetalle> detalle;

    float MontoPresupuesto()
    {
        float monto = 0;
        foreach (PresupuestoDetalle pd in detalle)
        {
            monto = monto + (pd.Producto.Precio * pd.Cantidad);
        }
        
        return monto;
    }

    double montoPresupuestoConIva()
    {
        return (MontoPresupuesto() * 1.21);
    }

    int cantidadProductos()
    {
        return detalle.Count;
    }
    
}