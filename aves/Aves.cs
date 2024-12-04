namespace Aves;

public abstract class Ave{
    public int Peso {get; init;}
    protected Ave(int peso) => Peso = peso;
}

public abstract class AveNoVoladora:Ave{
    
    protected AveNoVoladora(int peso):base(peso){}
}

public abstract class AveVoladora:Ave{
    
    public int Velocidad{get; init;}
    protected AveVoladora(int peso,int velocidad):base(peso){
        Velocidad = velocidad;
    }
}

public class Pinguino:AveNoVoladora{
    public Pinguino(int peso):base(peso){}
}
public class Aguila:AveVoladora{
    public Aguila(int velocidad,int peso):base(velocidad,peso){}
}
public class Paloma :AveVoladora{
    public Paloma(int peso,int velocidad):base(peso,velocidad){}
}

public static class Printer{
    public static Action<Ave,Action<Object>> PrintAve => (ave,writer)=>writer(ave);
    public static Action<AveVoladora,Action<Object>> PrintAveVoladora => (ave,writer)=>writer(ave);
    public static Action<AveNoVoladora,Action<Object>> PrintAveNoVoladora => (ave,writer)=>writer(ave);
}

public class TestAves
{
    public TestAves()
    {
        var pinguino = new Pinguino(5);
        var aguila = new Aguila(10,100);
        Printer.PrintAve(pinguino,Console.WriteLine);
        Printer.PrintAve(aguila,Console.WriteLine);
        Printer.PrintAveVoladora(aguila,Console.WriteLine);
        Printer.PrintAveNoVoladora(pinguino,Console.WriteLine);
    }    
}

