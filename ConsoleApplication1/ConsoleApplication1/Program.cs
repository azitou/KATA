using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
        }



    }

    public class FizzBuzzTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Should_Get_N_When_Pass_N(string expected, int n)
        {
            Assert.Equal(expected, FizzBuzz.Process(n));
        }

        [Fact]
        public void Should_Get_Fizz_When_Pass_3()
        {
            Assert.Equal("fizz", FizzBuzz.Process(3));
        }

        [Fact]
        public void Should_Get_Fizz_When_Pass_5()
        {
            Assert.Equal("buzz", FizzBuzz.Process(5));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void Should_Get_Fizzbuzz_When_Pass_divible_by_15_N(int n)
        {
            Assert.Equal("fizzbuzz", FizzBuzz.Process(n));
        }
    }

    public class FizzBuzz
    {
        public static string Process(int i)
        {
            if (i % 3 == 0)
            {
                if (i % 5 == 0)
                    return "fizzbuzz";
                return "fizz";
            }

            if (i % 5 == 0)
                return "buzz";

            return i.ToString();
        }
    }
}
