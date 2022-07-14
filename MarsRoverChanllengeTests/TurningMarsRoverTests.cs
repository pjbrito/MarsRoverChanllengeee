using MarsRoverChanllenge.MRModels;

namespace MarsRoverChanllengeTests
{
    public class TurningMarsRoverTests
    {
        [Fact]
        public void TurnLeft_TurningLeftWhenHeading_N_ResultsIn_W()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 N";
            // act
            string output_str = uut.TurnLeft(input_str);

            // assert
            Assert.Equal("0 0 W", output_str);
        }
    }

}