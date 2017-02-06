using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApplication1
{

    public class FooBarQixTests
    {
        [Fact]
        public void Should_Get_1_When_pass_1()
        {
            Assert.Equal("1", FooBarQix.Process(1));
        }

        [Fact]
        public void Should_Get_1_When_pass_2()
        {
            Assert.Equal("2", FooBarQix.Process(2));
        }

        [Fact]
        public void Should_Get_N_When_pass_Not_Divisible_by_and_not_contain_3_or_5_or_7()
        {
            Assert.Equal("16", FooBarQix.Process(16));
        }
        [Fact]
        public void Should_Get_FooFoo_When_pass_3()
        {
            Assert.Equal("FooFoo", FooBarQix.Process(3));
        }
        [Fact]
        public void Should_Get_BarBar_When_pass_5()
        {
            Assert.Equal("BarBar", FooBarQix.Process(5));
        }
        [Fact]
        public void Should_Get_BarBar_When_pass_7()
        {
            Assert.Equal("QixQix", FooBarQix.Process(7));
        }

        [Fact]
        public void Should_Get_Foo_When_pass_13()
        {
            Assert.Equal("Foo", FooBarQix.Process(13));
        }
        [Fact]
        public void Should_Get_Bar_When_pass_56()
        {
            Assert.Equal("Bar", FooBarQix.Process(58));
        }
        [Fact]
        public void Should_Get_Bar_When_pass_74()
        {
            Assert.Equal("Qix", FooBarQix.Process(74));
        }

        [Fact]
        public void Should_Get_FooBarBar_When_pass_15()
        {
            Assert.Equal("FooBarBar", FooBarQix.Process(15));
        }

        [Fact]
        public void Should_Get_FooBarBar_When_pass_33()
        {
            Assert.Equal("FooFooFoo", FooBarQix.Process(33));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("FooBar", 51)]
        [InlineData("BarFoo", 53)]
        [InlineData("FooFooFooFoo", 333)]
        [InlineData("FooFooFoo", 3313)]
        [InlineData("FooQixFooBarQix", 357)]
        public void Should_Get_N_When_Pass_N(string expected, int n)
        {
            Assert.Equal(expected, FooBarQix.Process(n));
        }

    }

    public class FooBarQix
    {
        public static string Process(int n)
        {
            var result = GetDivisibilityString(n) + GetContainString(n);
            return String.IsNullOrEmpty(result) ? n.ToString() : result;
        }

        private static string GetContainString(int i)
        {
            var sb = new StringBuilder();
            Regex rgx = new Regex("\\d+",RegexOptions.Compiled);
            i.ToString().ToList()
                .ForEach(x => 
                sb.Append(x.ToString().Replace("3","Foo")
                .Replace("5", "Bar")
                .Replace("7", "Qix"))
                );
           
            return rgx.Replace(sb.ToString(), "");

        }

        private static string GetDivisibilityString(int i)
        {
            var sb = new StringBuilder(); 
            if (i % 3 == 0)
                sb.Append("Foo");
            if (i % 5 == 0)
                sb.Append("Bar");
            if (i % 7 == 0)
                sb.Append("Qix");
            return sb.ToString();
        }
    }


}
