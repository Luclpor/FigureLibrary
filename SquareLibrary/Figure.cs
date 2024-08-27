public abstract class Figure
{
    /// <summary>
    /// <Базовый конструктор абстракного класса>
    /// <Выполняет инициализацию полей дочернего класса и проверяет корректность фигуры
    /// </summary>
    /// <param name="sides">Имя стороны и значение</param>
 
    public Figure(Dictionary<string,double> sides)
    {
        InitializeFields(sides);
        CheckCorrectFigure();
    }
    public abstract void InitializeFields(Dictionary<string,double> sides);
    public abstract double GetSquare();

    public static double GetSquare(Figure figure)
    {
        return figure.GetSquare();
    }

     public abstract bool CheckCorrectFigure();
    
}