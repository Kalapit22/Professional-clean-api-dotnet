namespace Core.Entities;


public class Marca : BaseEntity{

    public string Name {get;set;}

    public ICollection<Producto> Productos {get;set;}



}