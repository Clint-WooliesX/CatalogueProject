using NUnit.Framework;

namespace CatalogTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalcGST()
    {
        double result = TwoWheels.Products.CalculateGST(100);
        Assert.AreEqual(10, result);
    }
}
