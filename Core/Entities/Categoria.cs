namespace Core.Entities;

public class Categoria : BaseEntity{

    public string Name {get;set;}

    public ICollection<Producto> Productos {get;set;}


}