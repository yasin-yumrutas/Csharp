using Moq;
using Moq.Language.Flow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UdemyUnitTest.App;
using Xunit;

namespace UdemyUnitTest.Test
{
    public class HesaplamaTest
    {

        public Hesaplama hesaplama { get; set; }
        public Mock<IHesaplamaService> mymock { get; set; }
        public HesaplamaTest()
        {
            mymock = new Mock<IHesaplamaService>();
            this.hesaplama = new Hesaplama(mymock.Object);

        }/*
        [Fact]
        public void Add_simpleValues_returnTotal1()
        {
            //Arrange
            int a = 5;
            int b = 10;


            //Act

            var result = hesaplama.Add(a, b);


            //Assert

            Assert.Equal(15, result);
            //************************************************************************



            //string temp = "nasıl yani";


            //Assert.Contains("sin y", "yasin yumrutaş");
            //Assert.DoesNotContain("n",temp);



            //var temp = new List<string>() { "yasin", "enver", "mustafa" };
            //Assert.Contains(temp,x =>x=="yasin" );

            //-----> Burda değer tam girmelidir 
            //var temp = new List<string>() {"yasin","enver","mustafa" };
            //Assert.Contains("ya", temp);                                      


            //Assert.False(5<2);
            //Assert.True("".GetType() == typeof(string));


            //var regex = "^dog"; //---->begin dog
            //Assert.Matches(regex, "dog yasin");

            //Assert.StartsWith("masal", "masal anlat");
            //Assert.EndsWith("bitti", "masal bitti");

            //Assert.Empty(new List<string>() {"yasin" });

            //Assert.InRange(1500000, -150, 200000000000);

            //Assert.Single(new List<string>() { "nasi ya","tamam "});

            //Assert.IsType<int>(10);
            //Assert.IsNotType<string>(10);

            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>() {"" });
            //Assert.IsAssignableFrom<object>(new List<int>());

            //Assert.NotNull(new List<string>() {"aa"});

        }*/
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(-290, 300, 10)]
        [InlineData(0, 20, 0)]
        public void Add_simpleValues_returnTotal2(int a, int b, int expectedTotal)
        {

            mymock.Setup(x => x.Add(a, b)).Returns(expectedTotal);
            var actualTotal = hesaplama.Add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
            mymock.Verify(x => x.Add(a, b), Times.Once());

        }
        [Theory]
        [InlineData(10, 20, 200)]
        public void Multip_simpleValues_returnMultip(int a, int b, int expectedTotal)
        {
            int actualTotal = 0;

            mymock.Setup(x => x.Multip(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((x, y) => actualTotal = x * y);


            hesaplama.Multip(30, 7);
            Assert.Equal(210, actualTotal);


            hesaplama.Multip(20, 5);
            Assert.Equal(100, actualTotal);

            hesaplama.Multip(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(0, 20)]
        public void Multip_zeroValue_returnExeption(int a, int b)
        {
            mymock.Setup(x => x.Multip(a, b)).Throws(new Exception("a=0 olamaz"));
            Exception exception = Assert.Throws<Exception>(() => hesaplama.Multip(a, b));
            Assert.Equal("a=0 olamaz", exception.Message);

        }
    }
}
