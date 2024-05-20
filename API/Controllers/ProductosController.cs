using Core.Entities;
using Infraestructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductosController : BaseApiController {

    private readonly TiendaContext _context;

    public ProductosController(TiendaContext context) {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get() {

        IEnumerable<Producto> productos = await _context.Productos.ToListAsync();
        return Ok(productos);

    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Producto>> GetOne(int id) {

        Producto producto = await _context.Productos.FindAsync(id);
        return Ok(producto);

    }






}