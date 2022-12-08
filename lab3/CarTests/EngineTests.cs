using Car;
using Xunit;

namespace CarTests
{
    public class EngineTests
    {
        [Fact]
        public void TurnOnEngineThatIsTurnedOff_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();

            Assert.True(car.IsTurnedOn);
        }

        [Fact]
        public void TurnOnEngineThatIsTurnedOn_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.TurnOnEngine();

            Assert.True(car.IsTurnedOn);
        }

        [Fact]
        public void TurnOffEngineThatIsTurnedOn_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.TurnOffEngine();

            Assert.True(!car.IsTurnedOn);
        }

        [Fact]
        public void TurnOffEngineThatIsTurnedOff_ReturnTrue()
        {
            var car = new Car.Car();

            car.TurnOffEngine();

            Assert.True(!car.IsTurnedOn);
        }

        [Fact]
        public void TurnOffEngineWithNonZeroGear_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.TurnOffEngine();

            Assert.False(!car.IsTurnedOn);
        }

        [Fact]
        public void TurnOffEngineWithNonZeroSpeed_ReturnFalse()
        {
            var car = new Car.Car();

            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(15);
            car.SetGear(0);
            car.TurnOffEngine();

            Assert.False(!car.IsTurnedOn);
        }
    }
}
