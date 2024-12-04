namespace Record;

public class Entity{
    public Guid Id { get; init;}
    public Entity(Guid id){
        Id = id;
    }

    public static bool operator ==(Entity v1, Entity v2)
    {
        return v1.Id == v2.Id;
    }

    public static bool operator !=(Entity v1, Entity v2)
    {
        return v1.Id != v2.Id;
    }

    public override bool Equals(object? obj)
    {
        if(obj is Entity entity){
            return entity.Id == Id;
        }
        return false;
    }

    public override int GetHashCode(){
        return Id.GetHashCode();
    }
}

public class TestEntity{
    public TestEntity(){
        var Id = Guid.NewGuid();
        var entity = new Entity(Id);
        var entity1 = new Entity(Id);
        
        Console.WriteLine(entity1==entity); //true

        Console.WriteLine(entity1.Equals(entity)); //true

        //size == 1
        var set = new HashSet<Entity>(){
            entity,entity1
        };
        Console.WriteLine(set.Count); //1
    }
}