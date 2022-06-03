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

    [Test]
    public void Test_StringWrappiing()
    {
        string text = "A paragraph is a coherent block of text, such as a group of related sentences that develop a single topic or a coherent part of a larger topic. A blank line contains zero or more non-printing characters, such as space or tab, followed by a new line.";
        string result = TwoWheels.Products.WordWrapping(text);
        string[] MaxCharsOnLine = result.Split("\n");
        string[] textNumOfWords = text.Split(" ");
        string[] resultNumOfWords = text.Split(" ");

        Assert.AreEqual(textNumOfWords.Length, resultNumOfWords.Length); // test still contains the same number of words

        foreach(string Line in MaxCharsOnLine)
        {
            Assert.LessOrEqual(Line.Length, 50); // test each line in the Wrapped paragraph is 50characters or less
        }
    }
}
