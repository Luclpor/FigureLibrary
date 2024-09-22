namespace SquareLibraryTest;
using SquareLibrary;

[TestClass]
public class TriangleTest
{
    public static IEnumerable<object[]> GetTriangleData()
    {

        yield return new object[] { 1, 3, 3,1.48 };
    }

    [TestMethod]
    [DynamicData(nameof(GetTriangleData), DynamicDataSourceType.Method)]
    public void GetSquare_ReturnsCorrectSquare_ForVariousTriangles(double legOne, double legTwo, double hypotenuse, double expectedSquare)
    {
        // legOne = 3;
        // legTwo = 4;
        // hypotenuse = 5;
        Triangle triangle = new Triangle(legOne, legTwo, hypotenuse);

        // Act
        double result = triangle.GetSquare();

        // Assert
        Assert.AreEqual(expectedSquare, result);
    }

    static IEnumerable<object[]> GetWrongTriangle()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new object[] { 1, i, 34 };
        }
    }
    [TestMethod]
    [DynamicData(nameof(GetWrongTriangle), DynamicDataSourceType.Method)]
    public void Check_Correct_Triangle(double legOne, double legTwo, double hypotenuse)
    {
        Assert.ThrowsException<ArgumentException>(() => new Triangle(legOne, legTwo, hypotenuse));
    }


    [TestMethod]
    [DataRow(3, 4, 5)]  // классический прямоугольный треугольник
    [DataRow(5, 12, 13)] // прямоугольный треугольник
    [DataRow(8, 15, 17)] // прямоугольный треугольник
    [DataRow(7, 24, 25)] // прямоугольный треугольник
    [DataRow(9, 12, 15)] // прямоугольный треугольник, скалированный от 3, 4, 5
    public void Check_Right_Triangle(double legOne, double legTwo, double hypotenuse)
    {

        Assert.AreEqual(TriangleType.Right, new Triangle(legOne, legTwo, hypotenuse).Type);
    }
}