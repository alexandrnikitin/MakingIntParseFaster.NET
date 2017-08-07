using Xunit;

namespace MakingIntParseFaster.Tests
{
    public class V4Tests
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, V4.FasterInt.Parse("1"));
            Assert.Equal(123, V4.FasterInt.Parse("123"));
            Assert.Equal(2147483647, V4.FasterInt.Parse("2147483647"));
            //Assert.Equal(-1, V4.FasterInt.Parse("-1"));

        }
    }
}
