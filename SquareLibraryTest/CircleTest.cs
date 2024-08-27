namespace SquareLibraryTest;
using SquareLibrary;

[TestClass]
public class CircleTest
{
    [TestMethod]
    [DynamicData(nameof(GetWrongCircle), DynamicDataSourceType.Method)]
    public void Check_Correct_Circle(double radius)
    {
        Assert.ThrowsException<ArgumentException>(()=> new Circle(radius));
    }
    static IEnumerable<object[]> GetWrongCircle()
    {
        Random  random= new Random();
        int count =0;
        while(count < 100)
        {
            count++;
            yield return new object[]{random.Next(-1000,0)};
        }
    }

    [TestMethod]
    [DataRow(1, 3.14)]       // Площадь круга с радиусом 1: π * 1^2 ≈ 3.14
    [DataRow(2, 12.57)]      // Площадь круга с радиусом 2: π * 2^2 ≈ 12.57
    [DataRow(3, 28.27)]      // Площадь круга с радиусом 3: π * 3^2 ≈ 28.27
    [DataRow(5, 78.54)]      // Площадь круга с радиусом 5: π * 5^2 ≈ 78.54
    [DataRow(10, 314.16)]    // Площадь круга с радиусом 10: π * 10^2 ≈ 314.16
    public void Check_GetSquare_Circle(double radius, double expectedResult)
    {
        Assert.AreEqual(expectedResult,new Circle(radius).GetSquare());
    }
}