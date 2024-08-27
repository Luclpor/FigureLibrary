
using System.Reflection;

namespace SquareLibrary
{
    public class Circle : Figure
    {
        private double radius;
        public double Radius {get{return radius;}}
        public Circle(double radius) : base(new Dictionary<string,double> {{nameof(radius),radius}})
        {

        }

        public override bool CheckCorrectFigure()
        {
            if(Radius <= 0)
            {
                throw new ArgumentException("Radius must more zero");
            }

            return true;    
        }
        public override void Initialize(Dictionary<string, double> sides)
        {
            Type type = this.GetType();
            foreach(var side in sides)
            {
                FieldInfo field = type.GetField(side.Key, BindingFlags.NonPublic | BindingFlags.Instance);
                if(field is not null)
                {
                    field.SetValue(this,side.Value);
                }
            }
        }

        public override double GetSquare()
        {
            return Math.Round(Math.PI * Math.Pow(Radius,2),2);
        }
    }
}