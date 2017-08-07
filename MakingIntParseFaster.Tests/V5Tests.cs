using System;
using Xunit;

namespace MakingIntParseFaster.Tests
{
    public class V5Tests
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, V5.FasterInt.Parse("1"));
            Assert.Equal(123, V5.FasterInt.Parse("123"));
            Assert.Equal(2147483647, V5.FasterInt.Parse("2147483647"));

            Assert.Equal(-1, V5.FasterInt.Parse("-1"));
            Assert.Equal(-123, V5.FasterInt.Parse("-123"));
            Assert.Equal(-2147483648, V5.FasterInt.Parse("-2147483648"));


            Assert.Equal(123, V5.FasterInt.Parse(" 123"));
            Assert.Equal(123, V5.FasterInt.Parse("123 "));
            Assert.Equal(123, V5.FasterInt.Parse(" 123 "));
            Assert.Equal(123, V5.FasterInt.Parse(" 123 \0"));


            Assert.Throws<OverflowException>(() => V5.FasterInt.Parse("2147483649"));

        }
    }
}
