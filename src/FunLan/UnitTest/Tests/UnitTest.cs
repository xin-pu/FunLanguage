using Xunit.Abstractions;

namespace UnitTest.Tests
{
    public class UnitTest : AbstractTest
    {
        public UnitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        public void Call(string s)
        {
            throw new ArgumentException();
        }

        [Fact]
        public void Test()
        {
            var d = fun<string>(Call);
            var res = d("hello");
            Print(res);
        }
    }
}