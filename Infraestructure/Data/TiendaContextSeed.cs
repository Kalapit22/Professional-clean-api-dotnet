using System.Globalization;
using System.Reflection;
using Core.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Data;


public class TiendaContextSeed {


    public static async Task SeedAsync(TiendaContext tiendaContext, ILoggerFactory loggerFactory) {

        try {

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if(!tiendaContext.Marcas.Any()) {

                    using(var readerMarcas = new StreamReader(path+@"/Data/Csvs/marcas.csv")){
                        using(var csvMarcas = new CsvReader(readerMarcas,CultureInfo.InvariantCulture)) {
                                IEnumerable<Marca> marcas = csvMarcas.GetRecords<Marca>();
                                tiendaContext.Marcas.AddRange(marcas);
                                await tiendaContext.SaveChangesAsync();
                        }
                    }
            }

            if(!tiendaContext.Categorias.Any()) {

                using(var readerCategorias = new StreamReader(path+@"/Data/Csvs/categorias.csv")){
                    using(var csvMarcas = new CsvReader(readerCategorias,CultureInfo.InvariantCulture)) {
                        IEnumerable<Categoria> categorias = csvMarcas.GetRecords<Categoria>();
                        tiendaContext.Categorias.AddRange(categorias);
                        await tiendaContext.SaveChangesAsync();
                    }
                }
            }


            if (!tiendaContext.Productos.Any()) {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var readerProductos = new StreamReader(path + @"/Data/Csvs/productos.csv")) {
                using (var csvProductos = new CsvReader(readerProductos, config)) {
                    IEnumerable<Producto> listadoProductosCsv = csvProductos.GetRecords<Producto>();

                    List<Producto> productos = new List<Producto>();

                    foreach (var producto in listadoProductosCsv) {
                        productos.Add(new Producto {
                            Id = producto.Id,
                            Name = producto.Name,
                            Precio = producto.Precio,
                            FechaCreacion = producto.FechaCreacion,
                            MarcaId = producto.MarcaId,
                            CategoriaId = producto.CategoriaId
                        });
                    }

                    tiendaContext.Productos.AddRange(productos);
                    await tiendaContext.SaveChangesAsync();
                }
            }
        }


        } catch(Exception ex) {
            ILogger<TiendaContextSeed> logger = loggerFactory.CreateLogger<TiendaContextSeed>();
            logger.LogError(ex.Message);
        }





    }



}