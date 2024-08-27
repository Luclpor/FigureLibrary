public abstract class Figure
{
    public Figure(Dictionary<string,double> sides)
    {
        Initialize(sides);
        CheckCorrectFigure();
    }
    public abstract void Initialize(Dictionary<string,double> sides);
    public abstract double GetSquare();

    public static double GetSquare(Figure figure)
    {
        return figure.GetSquare();
    }

     public abstract bool CheckCorrectFigure();
    
}