using Microsoft.AspNetCore.Mvc;
using repositorys;

namespace models.Controllers;


[ApiController]
[Route("[controller]")]

public class PresupuestoController : ControllerBase
{
    
    private PresupuestosRepository presupuestoRepository;
    //private List<Producto> listaProductos;
    public PresupuestoController()
    {
        presupuestoRepository = new PresupuestosRepository();
    }

    [HttpPost("/api/Presupuesto")]
    public ActionResult<Presupuesto> PostPresupuesto(Presupuesto presupuesto)
    {
        presupuestoRepository.CrearPresupuesto(presupuesto);
        return Ok(presupuesto);
    }

    
    [HttpGet("/api/Presupuestos")]
    public ActionResult<List<Presupuesto>> GetPresupuestos()
    {
        List<Presupuesto> listaPresupuestos = presupuestoRepository.ObtenerPresupuestos();
        return Ok(listaPresupuestos);
    }

    [HttpPut("/api/Presupuesto/{idPresupuesto}/{idProducto}/{cantidad}")]
    public ActionResult<Presupuesto> addDetalle(int idPresupuesto, int idProducto,int cantidad)
    {
        Presupuesto p = presupuestoRepository.agregarDetalle(idPresupuesto, idProducto, cantidad);
        if (p != null)
        {
            return Ok(p);
        }else{
            return BadRequest(p);
        }
    }

    [HttpGet("getDetalle_Extra/{id}")]
    public ActionResult<Presupuesto> GetDetalle(int id)
    {
        return Ok(presupuestoRepository.ObtenerDetalle(id));
    }

    [HttpDelete("deletePresupuesto_Extra/{idPresupuesto}")]
    public ActionResult<bool> delete(int idPresupuesto)
    {
        presupuestoRepository.EliminarPresupuesto(idPresupuesto);
        return Ok(true);
    }
}