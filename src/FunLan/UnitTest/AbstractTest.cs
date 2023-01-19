using Xunit.Abstractions;

namespace UnitTest
{
    public abstract class AbstractTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        protected AbstractTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        internal void Print(object obj)
        {
            _testOutputHelper.WriteLine(obj.ToString());
        }
    }
}