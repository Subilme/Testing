using Car;
using Xunit;

namespace CarTests
{
    public class SpeedTests
    {
        [Fact]
        public void SetSpeedWithTurnedOffCar_ReturnFalse()
        {
            var car = new Car.Car();

            car.SetSpeed(10);

            Assert.False(car.Speed == 10);
        }

        [Fact]
        public void SetSpeedOutOfRange_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(50);
            car.SetGear(5);
            car.SetSpeed(180);

            Assert.False(car.Speed == 180);
        }

        [Fact]
        public void SetSpeedReverseOutOfRange_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(-1);
            car.SetSpeed(30);

            Assert.False(car.Speed == -30);
        }

        [Fact]
        public void SetSpeedReverseCorrectParameter_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(-1);
            car.SetSpeed(15);

            Assert.True(car.Speed == -15);
        }

        [Fact]
        public void IncreaseSpeedOnNeutralGear_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(6);
            car.SetGear(0);
            car.SetSpeed(15);

            Assert.False(car.Speed == 15);
        }

        [Fact]
        public void DecreaseSpeedOnNeutralGear_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(15);
            car.SetGear(0);
            car.SetSpeed(6);

            Assert.True(car.Speed == 6);
        }

        [Fact]
        public void SetSpeedOutOfGearRange_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(50);

            Assert.False(car.Speed == 50);
        }
    }
}
