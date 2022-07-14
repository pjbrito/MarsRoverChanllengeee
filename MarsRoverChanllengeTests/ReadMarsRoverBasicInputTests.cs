using MarsRoverChanllenge.MRModels;

namespace MarsRoverChanllengeTests
{
    public class ReadMarsRoverBasicInputTests
    {
        [Fact]
        public void Move_MovingForwardFromPos_2_3_N_ResultsIn_2_4_N()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
2 3 N
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("2 4 N", output_str);
        }

        [Fact]
        public void Move_MovingForwardFromPos_2_3_S_ResultsIn_2_2_S()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
2 3 S
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("2 2 S", output_str);
        }

        [Fact]
        public void Move_MovingForwardFromPos_1_1_E_ResultsIn_1_2_E()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"2 2
1 1 E
M";
            // act
            string output_str = uut.ProcessCommands(input_str);

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
            uut.ProcessCommands(input_str);
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
            uut.TryParseGridConfiguration(input_str);

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
            uut.TryParseGridHeader(input_str);

            //TryParseGridHeader
            Assert.Equal(1, uut.MaxLength);
            Assert.Equal(2, uut.MaxHeight);
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
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("1 3 N\r\n5 1 E", output_str);
        }

        [Fact]
        public void Move_SingleRoverWithCommands_MLM_FromPosition_2_2_E_ResultsIn_3_3_N()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
2 2 E
MLM";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("3 3 N", output_str);
        }

        [Fact]
        public void Move_SingleRoverWithCommands_MRM_FromPosition_2_2_E_ResultsIn_3_1_S()
        {
            // arrange
            var uut = new MarsRover();
            var input_str = @"5 5
2 2 E
MRM";
            // act
            string output_str = uut.ProcessCommands(input_str);

            // assert
            Assert.Equal("3 1 S", output_str);
        }


    }

}