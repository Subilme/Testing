using Car;
using Xunit;

namespace CarTests
{
    public class GearTests
    {
        [Fact]
        public void SetGearWithTurnedOffCar_ReturnFalse()
        {
            var car = new Car.Car();

            car.SetGear(1);

            Assert.False(car.Gear == 1);
        }

        [Fact]
        public void SetGearOutOfRange_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(8);

            Assert.False(car.Gear == 8);
        }

        [Fact]
        public void SetGearReverseWithCorrectParameters_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(-1);

            Assert.True(car.Gear == -1);
        }

        [Fact]
        public void SetGearReverseWithSpeedMoreThanZero_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(10);
            car.SetGear(-1);

            Assert.False(car.Gear == -1);
        }

        [Fact]
        public void SetGearNeutralOnTheMove_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(15);
            car.SetGear(0);

            Assert.True(car.Gear == 0);
        }

        [Fact]
        public void SetGearWithCorrectParameters_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(50);
            car.SetGear(5);
            car.SetSpeed(150);

            Assert.True(car.Gear == 5 && car.Speed == 150);
        }

        [Fact]
        public void SetGearOutOfSpeedRange_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(3);

            Assert.False(car.Gear == 3);
        }
    }
}
