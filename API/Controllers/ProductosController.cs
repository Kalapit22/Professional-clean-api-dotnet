using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductosController : BaseApiController {

    private readonly IProductoRepository _productoRepository;

    public ProductosController(IProductoRepository productoRepository) {
        _productoRepository = productoRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get() {

        IEnumerable<Producto> productos = await _productoRepository.GetAllAsync();
        return Ok(productos);

    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Producto>> GetOne(int id) {

        Producto producto = await _productoRepository.GetByIdAsync(id);
        return Ok(producto);

    }






}