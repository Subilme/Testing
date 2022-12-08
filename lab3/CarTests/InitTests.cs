using Car;
using Xunit;

namespace CarTests
{
    public class InitTests
    {
        [Fact]
        public void InitializeCar_ReturnTrue()
        {
            var car = new Car.Car();

            Assert.True(!car.IsTurnedOn && car.Speed == 0 && car.Gear == 0 && car.Direction == Directions.None);
        }
    }
}
