using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTest.Tests
{
    public class LambdaTest : AbstractTest
    {
        public LambdaTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestFun()
        {
            var add = fun((int x, int y) => x + y);
            var res = add(1, 2);
            res.Should().Be(3);
        }

        [Fact]
        public void TestAct()
        {
            var add = act((int x, int y) =>
            {
                var d = x + y;
                Print(d);
            });
            add(1, 2);
        }
    }
}