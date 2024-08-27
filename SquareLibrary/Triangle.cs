using System.Reflection;

namespace SquareLibrary
{
    public enum TriangleType
    {
        Isosceles,
        Right,
        Scalene
    }
    public class Triangle : Figure
    {
        private double legOne;
        public double LegOne {get{return legOne;}}
        private double legTwo;
        public double LegTwo {get{return legTwo;}}
        private double hypotenuse;
        public double Hypotenuse {get{return hypotenuse;}}

        private TriangleType type;
        public TriangleType Type {get{return type;}}
        
        public Triangle(double legOne, double legTwo,double hypotenuse) : base(new Dictionary<string,double>{{nameof(legOne),legOne},{nameof(legTwo),legTwo},{nameof(hypotenuse),hypotenuse}})
        {
            GetTypeTriangle();
        }

        public Triangle(Dictionary<string,double> sides) : base(sides)
        {

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


        public override bool CheckCorrectFigure()
        {
            if(LegOne <= 0 || LegTwo <= 0 || Hypotenuse <= 0)
            {
                throw new ArgumentException("Someone side less than 0");
            }
            else if(LegOne + LegTwo <= Hypotenuse || LegOne + Hypotenuse <= LegTwo || LegTwo + Hypotenuse <= LegOne )
            {
                throw new ArgumentException("This hypotenuse less than sum of legs");
            }
            else
            {
                return true;
            }
        }


        public override double GetSquare()
        {
            double s = (LegOne + LegTwo + Hypotenuse)/2;
            return Math.Round(Math.Sqrt(s * (s - LegOne)*(s - LegTwo) *(s - Hypotenuse)),2);
        }

        void GetTypeTriangle()
        {
            if(LegOne == LegTwo)
            {
                type = TriangleType.Isosceles;
            }
            else if(Math.Pow(Hypotenuse,2) == (Math.Pow(LegOne,2) + Math.Pow(LegTwo,2)))
            {
                type = TriangleType.Right;
            }
            else
            {
                type = TriangleType.Scalene;
            }
        }
    }
}