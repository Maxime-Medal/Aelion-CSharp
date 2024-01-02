/// <summary>
/// NUnit Test
/// </summary>
public class EuclideTests
{
    // pas besoisn de setup pour du test basique

    [Test]
    public void GcdTest_WhenSameValue()
    {
        UInt64 n = 12;
        UInt64 g = Euclide.Gcd(n, n);
        Assert.That(n, Is.EqualTo(g));
    }

    // Test diferent cases
    [TestCase(123UL, 1921UL)]
    [TestCase(17UL, 1UL)]
    [TestCase(1UL, 17UL)]
    [TestCase(3UL, 5UL)]
    public void GcdTest_When1(UInt64 a, UInt64 b)
    {
        //UInt64 n = 1;
        //UInt64 a = 123;
        //UInt64 b = 1921;
        UInt64 g = Euclide.Gcd(a, b);
        Assert.That(g, Is.EqualTo(1));
    }

    [Test]
    public void GcdTest_WhenFirstGreater()
    {
        UInt64 a = 36;
        UInt64 b = 60;
        UInt64 g = Euclide.Gcd(b, a);
        Assert.That(g, Is.EqualTo(12));
    }

    [Test]
    public void GcdTest_WhenSecondGreater()
    {
        UInt64 a = 36;
        UInt64 b = 60;
        UInt64 g = Euclide.Gcd(a, b);
        Assert.That(g, Is.EqualTo(12));
    }

    [Test]
    public void GcdTest_WhenArgIs0()
    {
        UInt64 a = 1;
        UInt64 b = 0;
        Assert.Throws<ArgumentException>(() =>  Euclide.Gcd(a,b)); // test via une fonction lambda(anonyme) pour attraper l'exception voulu

    }
}