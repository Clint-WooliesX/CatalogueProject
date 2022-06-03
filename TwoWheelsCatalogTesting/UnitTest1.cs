using NUnit.Framework;

namespace TwoWheelsCatalogTesting;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_CalculateGST()
    {
        double result = TwoWheels.Products.CalculateGST(1000);
        Assert.AreEqual(100, result);
        Assert.AreEqual(10, TwoWheels.Products.CalculateGST(100));
        Assert.AreEqual(0, TwoWheels.Products.CalculateGST(0));
        Assert.AreEqual(-9, TwoWheels.Products.CalculateGST(-90));
    }
}
