using Core.Interfaces;
using Infraestructure.Data;
using Core.Entities;
namespace Infraestructure.Repositories;

public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository {

            public MarcaRepository(TiendaContext context) : base(context) {}



}