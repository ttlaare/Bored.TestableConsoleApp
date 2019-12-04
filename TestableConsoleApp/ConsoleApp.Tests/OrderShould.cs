using NUnit.Framework;

namespace ConsoleApp.Tests
{
    public class OrderShould
    {

        [Test]
        [TestCase("1","1",4.4)]
        [TestCase("1", "2",4.9)]
        [TestCase("2", "1",3.90)]
        [TestCase("2", "2",4.4)]
        public void CalculateTotalPriceCorrectly(string input1, string input2, double expectedTotalPrice)
        {
            var console = new ConsoleWrapper();
            console.LinesToRead.Add(input1);
            console.LinesToRead.Add(input2);

            var sut = new Order(console);
            sut.PlaceFoodOrder();
            sut.PlaceDrinkOrder();
            var totalPrice = sut.CalculateTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(expectedTotalPrice).Within(0.004));
        }
    }
}