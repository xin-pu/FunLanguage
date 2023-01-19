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
            var repeat = Enumerable.Repeat(1, 5);
            foreach (var i in repeat)
            {
                var o = GetRandom();

                if (o.IsSome)
                    Print($"Hello {o.Case}");

                if (o.IsNone)
                    Print("Oh None");
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

        [Fact]
        public void IfNone()
        {
            var o = GetNone();
            var n = o.IfNone(10);
            n.Should().Be(10);
        }

        [Fact]
        public void IfSome()
        {
            var o = GetSome();
            o.IfSome(a => Print(a));
            o.IfSomeAsync(a => Task.Run(() => Print(a)));
        }


        [Fact]
        public void SetTest()
        {
            var list = List(Some(1), None);
            list = list.Map(x => x.Map(v => v * 2));
            foreach (var option in list) Print(option);
        }


        internal Option<int> GetNone()
        {
            return Option<int>.None;
        }

        internal Option<int> GetSome()
        {
            return 3;
        }

        internal Option<int> GetRandom()
        {
            var random = new Random();
            var value = random.Next(-1, 1);
            return value >= 0 ? Some(value) : None;
        }
    }
}