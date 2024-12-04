// See https://aka.ms/new-console-template for more information

//Extension method a.between(5,15)
/*
 Se puede extender cualquier tipo
    Interfaces
    Primitivas
    Clases
    static (this <type> value)
*/

List<int> list = [
    1,2,3,4,5,6,7 
];

var pares = list.Filter(v=>v%2==0);

foreach (var par in pares)
{
    Console.WriteLine(par);
}

int a = 10;
bool result = a.BetWeen(5,15);
Console.WriteLine(result);

//callback->consiste en pasar una metodo como parametro a otro metodo
Action<DateTime,Action<Object>> printDate = (date,writer)=>writer(date);
printDate(DateTime.Now, Console.WriteLine);

//clousure
Func<int,Func<int,int>> sum = a=>b=>a+b;

Console.WriteLine(sum(5)(3)); //8
//Operation<int>
//Func<int,int,int>
List<Func<int,int,int>> operations = [
    //(a,b)=>a+b, //suna
    Operations.sum,
    (a,b)=>a-b, //resta
    (a,b)=>a*b, //multiplicacion
    (a,b)=>a/b  //division
];





foreach (var item in operations)
{
    Console.WriteLine(item(2,2));
}







//https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/delegates/
/*
   puntero a una funcion como si fuese una interface con un solo metodo

   (a,b)=>a+b se puede instanciar con una lambda sin necesidad de crear ni clases
   ni metodos

*/
//public delegate T Operation<T>(T a,T b);
//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
public static class ExtensioInteger{

    public static bool BetWeen(this int value, int a,int b){
        return value>=a && value<=b;
    }
}

public static class Operations{
    public static int sum(int a,int b){
        return a+b;
    }
}

public static class ExtensionEnumerable{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> iterator, Func<T, bool> predicate){
        foreach (var item in iterator)
        {
            if(predicate(item)){
               yield return item; 
            }
        }
    }
}