using MarsRoverChanllenge.MRModels;

namespace MarsRoverChanllengeTests
{
    public class ReadMarsRoverBasicInputTests
    {
        [Fact]
        public void Move_MovingForwardFromPos_1_1_E_ResultsIn_1_2_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"2 2
1 1 E
M";
            // act
            string output_str = uut.Move(input_str);

            // assert
            Assert.Equal("2 1 E", output_str);
        }


        [Fact]
        public void MoveOneStep_MovingForwardFromPos_1_1_E_ResultsIn_1_2_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"2 2
1 1 E";
            uut.Move(input_str);
            // act
            uut.MoveOneStep("M");

            // assert
            Assert.Equal(1, uut.Y);
            Assert.Equal(2, uut.X);
            Assert.Equal("E", uut.Direction);
        }

        [Fact]
        public void TryParseGridConfiguration__ForInput_1_1_E__ResultsIn_X_1_Y_1_and_Direction_E()
        {
            // arrange
            var input_str = @"1 1 E";
            var uut = new MarsRover();

            // act
            uut.TryParseGridConfiguration(input_str, out int _, out int _, out string _);

            //TryParseGridHeader
            Assert.Equal(1, uut.X);
            Assert.Equal(1, uut.Y);
            Assert.Equal("E", uut.Direction);
        }

        [Fact]
        public void TryParseGridHeader_ParsingHeader_1_2_ResultsIn_MaxLength_1_and_MaxHeight_2()
        {
            // arrange
            var input_str = @"1 2";
            var uut = new MarsRover();

            // act
            uut.TryParseGridHeader(input_str, out int length, out int height);

            //TryParseGridHeader
            Assert.Equal(1, length);
            Assert.Equal(2, height);
        }

        [Fact]
        public void Move_ComplexRoverMove_Works()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";
            // act
            string output_str = uut.Move(input_str);

            // assert
            Assert.Equal("1 3 N\r\n5 1 E", output_str);
        }

    }

}