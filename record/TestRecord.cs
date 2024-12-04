namespace Record;

public readonly record struct Point(double X, double Y, double Z);

public class TextRecord{
    public TextRecord(){
        var point = new Point(0,0,0);
        var point1 = new Point(0,0,0);
        var list = new HashSet<Point>(){
            point,point1
        };
        Console.WriteLine(list.Count); //1
        Console.WriteLine(point == point1); // true
        Console.WriteLine(point1.Equals(point)); //true
    }
}
