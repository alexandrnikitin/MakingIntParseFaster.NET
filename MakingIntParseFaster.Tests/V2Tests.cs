using Xunit;

namespace MakingIntParseFaster.Tests
{
    public class V2Tests
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, V2.FasterInt.Parse("1"));
            Assert.Equal(123, V2.FasterInt.Parse("123"));
            Assert.Equal(2147483647, V2.FasterInt.Parse("2147483647"));
            //Assert.Equal(-1, V2.FasterInt.Parse("-1"));

        }
    }
}
