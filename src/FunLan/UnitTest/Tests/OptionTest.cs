using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTest.Tests
{
    public class OptionTest : AbstractTest
    {
        public OptionTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void CreateOption()
        {
            var repeat = Enumerable.Repeat(1, 10);
            foreach (var i in repeat)
            {
                var o = GetValue();
                Print(o);

                if (o.IsSome)
                    Print($"Hello {o.Case}");
            }
        }

        [Fact]
        public void MatchTest()
        {
            var a = Some(3);
            var x = a.Match(
                v => v + 1,
                () => int.MinValue);
            x.Should().Be(4);
        }


        internal Option<int> GetValue()
        {
            var random = new Random();
            var value = random.Next(-1, 2);
            return value >= 0 ? Some(value) : None;
        }
    }
}