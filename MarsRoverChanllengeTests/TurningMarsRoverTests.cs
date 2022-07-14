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
0 0 N
L";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 W", output_str);
        }

        [Fact]
        public void TurnLeft_TurningLeftWhenHeading_W_ResultsIn_S()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 W
L";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 S", output_str);
        }

        [Fact]
        public void TurnLeft_TurningLeftWhenHeading_S_ResultsIn_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 S
L";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 E", output_str);
        }

        [Fact]
        public void TurnLeft_TurningLeftWhenHeading_E_ResultsIn_N()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 E
L";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 N", output_str);
        }



        [Fact]
        public void TurnRight_TurningRightWhenHeading_N_ResultsIn_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 N
R";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 E", output_str);
        }

        [Fact]
        public void TurnRight_TurningRightWhenHeading_W_ResultsIn_N()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 W
R";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 N", output_str);
        }

        [Fact]
        public void TurnRight_TurningRightWhenHeading_S_ResultsIn_W()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 S
R";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 W", output_str);
        }

        [Fact]
        public void TurnRight_TurningRightWhenHeading_E_ResultsIn_S()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
0 0 E
R";
            // act

            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("0 0 S", output_str);
        }

    }

}