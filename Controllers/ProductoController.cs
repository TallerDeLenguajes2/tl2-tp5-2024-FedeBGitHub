using Microsoft.AspNetCore.Mvc;
using repositorys;

namespace models.Controllers;


[ApiController]
[Route("[controller]")]

public class ProducutoController : ControllerBase
{
    private ProductoRepository productoRepository;
    private List<Producto> listaProductos;
    public ProducutoController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpPost("PostProducto")]
    public ActionResult<Producto> PostProducto(Producto producto)
    {
        productoRepository.CrearProducto(producto);
        return Ok(producto);
    }

    [HttpGet("GetProductos")]
    public ActionResult<List<Producto>> GetProductos()
    {
        listaProductos = productoRepository.listarProductos();
        return Ok(listaProductos);
    }

    [HttpPut("UpdateProducto/{id}")]
    public ActionResult<bool> UpdateProducto(int id, Producto producto)
    {
        productoRepository.modificarProducto(id,producto);
        return Ok(true);
    }
}