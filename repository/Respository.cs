using System.ComponentModel;

namespace Repository;

public abstract class EntityBase{
    public Guid Id {get;init;}

    public EntityBase(Guid id) => Id = id;

    public override bool Equals(object? obj)
    {
        if(obj is EntityBase entityBase){
            return entityBase.Id == Id;
        }
        return false;
    }
    public override int GetHashCode(){
        return Id.GetHashCode();
    }

}

public class Customer : EntityBase
{
    public Customer(Guid id) : base(id)
    {
    }
}
public class User : EntityBase
{
    public User(Guid id) : base(id)
    {
    }
}

public interface IDatabase<T> where T:EntityBase{
    ICollection<T> Data{get;}
}
public interface IAdd<T>:IDatabase<T> where T:EntityBase{
    void Add(T entity){
        Data.Add(entity);
    }
}
public interface IGet<T,ID>:IDatabase<T> where T:EntityBase{
    T Get(ID id){
        var entity = Data.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if(entity == null){
            throw new Exception("");
        }
        return entity;
    }
}
public interface IUpdate<T,ID>:IGet<T,ID> where T:EntityBase{
    void Update(T entity){
        Data.Remove(entity);
        Data.Add(entity);
    }   
}
public interface IRemove<T,ID>:IGet<T,ID> where T:EntityBase{
    void Remove(T entity){
        Data.Remove(entity);
    }
}

public interface IReposiroty<T,ID>:IAdd<T>,IUpdate<T,ID>,IRemove<T,ID> where T:EntityBase{

}



public class ServiceCustomer : IReposiroty<Customer, Guid>
{
    private static readonly ISet<Customer> customers = new HashSet<Customer>(); 
    public ICollection<Customer> Data => customers;
}
public class ServiceUSer : IGet<User, Guid>
{
    private static readonly ISet<User> users = new HashSet<User>(); 
    public ICollection<User> Data => users;
}