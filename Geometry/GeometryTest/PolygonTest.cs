namespace Geometry.Model.Test
{
    public class PoligonTest
    {
        IList<Point> points = new List<Point>()
            {
                new() { Name = "O", X = 0.0, Y = 0.0 },
                new() { Name = "A", X = 3.0, Y = 0.0 },
                new() { Name = "B", X = 0.0, Y = 4.0 },
                new() { Name = "D", X = 5.25, Y = 3.5 },
             };


        [Fact]
        public void Poligon_2SummitsTest()
        {
            Polygon p1 = new Polygon("p1", [points[0], points[1], points[2]]);
        }

        //[Theory]
        //[InlineData]
        //public void DistanceTest() { 

        //}
    }
}



//[Fact]
//public void GcdTest_WhenSameValue()
//{
//    UInt64 n = 12;
//    UInt64 g = Euclide.Gcd(n, n);
//    Assert.Equal(n, g);
//}

//[Theory]
//[InlineData(123UL, 1921UL)]
//[InlineData(17UL, 1UL)]
//[InlineData(1UL, 17UL)]
//[InlineData(3UL, 5UL)]

//public void GcdTest_When1(UInt64 a, UInt64 b)
//{
//    UInt64 g = Euclide.Gcd(a, b);
//    Assert.Equal(1UL, g);
//}