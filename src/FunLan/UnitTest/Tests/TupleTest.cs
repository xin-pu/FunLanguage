using FluentAssertions;
using LanguageExt.ClassInstances;
using Xunit.Abstractions;

namespace UnitTest.Tests
{
    public class TupleTest : AbstractTest
    {
        public TupleTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void CreateTuple()
        {
            var tuple = Tuple("a", "b");
            Print(tuple);
        }

        [Fact]
        public void MapTuple()
        {
            /// Tuple 最多可传入8个单元
            var tuple = Tuple("A", 3);
            var first = tuple.MapFirst(a => $"Hello {a}!");
            var second = tuple.MapSecond(a => a + 1);
            Print(first);
            Print(second);
            first.Item1.Should().Be("Hello A!");
            second.Item2.Should().Be(4);
        }

        [Fact]
        public void ValueTuple()
        {
            var abc = (1, 2).Add(3);
            var sum = abc.Sum<TInt, int>();
            Print(sum);
            sum.Should().Be(6);

            var res = abc.Contains<TInt, int>(3);
            res.Should().Be(true);
        }
    }
}