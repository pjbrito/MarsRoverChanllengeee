using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverChanllenge.MRModels
{
    public class MarsRover
    {
        public int MaxLength { get; set; }
        public int MaxHeight { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }

        public string ProcessCommands(string input_str)
        {
            var lines = SplitCommandLines(input_str);
            if (lines.Length >= 1)
            {
                TryParseGridHeader(lines[0]);
            }

            var processingResult = string.Empty;
            for (int i = 1; i < lines.Length; i+=2)
            {
                TryParseGridConfiguration(lines[i]);    // 1
                if (NextRoverInputHasMoves(lines, i))   // 2
                {
                    foreach (var move in lines[i + 1])
                    {
                        MoveOneStep($"{move}");
                    }
                    processingResult += $"{X} {Y} {Direction}\r\n";
                }
            }
            return processingResult.TrimEnd();
        }

        private static bool NextRoverInputHasMoves(string[] lines, int currentInputLine)
        {
            return lines.Length > currentInputLine + 1;
        }

        private string[] SplitCommandLines(string input_str)
        {
            var delimiters = new char[] { '\n', '\r' };
            if (string.IsNullOrEmpty(input_str))
                return new string[0];

            var lines = input_str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        public void MoveOneStep(string moveType)
        {
            if (moveType == "M")
            {
                if (Direction == "N" && Y < MaxHeight)
                {
                    Y += 1;
                }
                else if (Direction == "E" && X < MaxLength)
                {
                    X += 1;
                }
                else if (Direction == "S" && Y > 0)
                {
                    Y += -1;
                }
                else if (Direction == "W" && X > 0)
                {
                    X += -1;
                }
            }
            else if (moveType == "L")
            {
                TurnLeft($"{X} {Y} {Direction}");
            }
            else if (moveType == "R")
            {
                TurnRight($"{X} {Y} {Direction}");
            }
        }

        public string TurnLeft(string input_str)
        {
            if (Direction == "N")
            {
                Direction = "W";
            }
            else if (Direction == "E")
            {
                Direction = "N";
            }
            else if (Direction == "W")
            {
                Direction = "S";
            }
            else if (Direction == "S")
            {
                Direction = "E";
            }

            return $"{X} {Y} {Direction}";
        }

        public string TurnRight(string input_str)
        {
            if (Direction == "N")
            {
                Direction = "E";
            }
            else if (Direction == "E")
            {
                Direction = "S";
            }
            else if (Direction == "W")
            {
                Direction = "N";
            }
            else if (Direction == "S")
            {
                Direction = "W";
            }

            return $"{X} {Y} {Direction}";
        }

        public void TryParseGridHeader(string header_str)
        {
            var length = -1;
            var height = -1;

            var headerElements = header_str?.Split(" ");
            if (int.TryParse(headerElements[0], out length) &&
                int.TryParse(headerElements[1], out height))
            {
                MaxLength = length;
                MaxHeight = height;
            }
        }

        public void TryParseGridConfiguration(string config_str)
        {
            string[] configElements = null;
            var x = -1;
            var y = -1;
            CleanGlobalPositionXY();
            var direction = string.Empty;

            configElements = config_str?.Split(" ");

            if (configElements != null &&
                int.TryParse(configElements[0], out x) &&
                int.TryParse(configElements[1], out y) &&
                configElements[2]?.Length > 0)
            {
                X = x;
                Y = y;
                Direction = configElements[2];
            }
        }

        private void CleanGlobalPositionXY()
        {
            X = -1;
            Y = -1;
        }

    }
}
