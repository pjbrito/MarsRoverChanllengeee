using MarsRoverChanllenge.MRModels;

namespace MarsRoverChanllengeTests
{
    public class LimitMarsRoverTests
    {
        [Fact]
        public void Move_MovingForwardFromTheEdgeOfTheGrid_5_5_N_ResultsIn_5_5_N()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
5 5 N
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("5 5 N", output_str);
        }

        [Fact]
        public void Move_MovingForwardFromTheEdgeOfTheGrid_5_5_E_ResultsIn_5_5_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
5 5 E
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("5 5 E", output_str);
        }

        [Fact]
        public void Move_MovingForwardFromTheEdgeOfTheGrid_0_0_S_ResultsIn_0_0_S()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 S
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 S", output_str);
        }

        [Fact]
        public void Move_MovingForwardFromTheEdgeOfTheGrid_0_0_W_ResultsIn_0_0_W()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 W
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 W", output_str);
        }
    }

}