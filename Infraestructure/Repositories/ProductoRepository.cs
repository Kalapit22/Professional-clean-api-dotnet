using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class ProductoRepository : GenericRepository<Producto>,IProductoRepository {

        // Al utilizar el base context estoy heredando todos los metodos de GenericRepository, al heredar tambien de IProductoRepository le estoy diciendo
        // que debo implementar el Metodo de la interfaz corretamente, en este caso tendria acceso a los metodos y atributos _context y los metodos del repositorio
        public ProductoRepository(TiendaContext context) : base(context) {}

        public async Task<IEnumerable<Producto>> GetMoreExpensiveProducts(int cantidad) {
            return await _context.Productos
            .OrderByDescending(p => p.Precio)
            .Take(cantidad)
            .ToListAsync();
        }

}