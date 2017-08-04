using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MakingIntParseFaster.Tests
{
    public class V2Tests
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, V2.FasterInt.Parse("1"));
            Assert.Equal(-1, V2.FasterInt.Parse("-1"));

        }
    }
}
