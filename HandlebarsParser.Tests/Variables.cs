using Sprache;

namespace HandlebarsParser.Tests;

public class Variables
{
    [Fact]
    public void Test1()
    {
        var expr = HandlebarsExpression.Parse("abc.def");
    }
}