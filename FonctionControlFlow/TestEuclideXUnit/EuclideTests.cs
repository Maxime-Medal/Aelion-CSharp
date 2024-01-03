public class EuclideTests
{
    [Fact]
    public void GcdTest_WhenSameValue()
    {
        UInt64 n = 12;
        UInt64 g = Euclide.Gcd(n, n);
        Assert.Equal(n, g);
    }

    [Theory]
    [InlineData(123UL, 1921UL)]
    [InlineData(17UL, 1UL)]
    [InlineData(1UL, 17UL)]
    [InlineData(3UL, 5UL)]

    public void GcdTest_When1(UInt64 a, UInt64 b)
    {
        UInt64 g = Euclide.Gcd(a, b);
        Assert.Equal(1UL, g);
    }
}
