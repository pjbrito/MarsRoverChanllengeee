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

        public string Move(string input_str)
        {
            string[] headerElements = null;
            var lines = input_str?.Split("\r\n");
            if (lines.Length >= 2)
            {
                TryParseGridHeader(lines[0], out int _, out int _);
                TryParseGridConfiguration(lines[1], out int _, out int _, out string _);
            }

            if (lines.Length > 2 && lines[2]?.Length >= 1)
            {
                // move
                foreach (var move in lines[2])
                {
                    MoveOneStep($"{move}");
                }
            }


            return $"{X} {Y} {Direction}";
        }

        public void MoveOneStep(string moveType)
        {
            if (moveType == "M")
            {
                if (Direction == "N")
                {
                    Y += 1;
                }
                else if (Direction == "E")
                {
                    X += 1;
                }
                else if (Direction == "S")
                {
                    Y += -1;
                }
                else if (Direction == "W")
                {
                    X += -1;
                }
            }
        }

        public void TryParseGridHeader(string header_str, out int length, out int height)
        {
            length = -1;
            height = -1;

            var headerElements = header_str?.Split(" ");
            if (int.TryParse(headerElements[0], out length) &&
                int.TryParse(headerElements[1], out height))
            {
                MaxLength = length;
                MaxHeight = height;
            }
        }

        public void TryParseGridConfiguration(string config_str, out int x, out int y, out string direction)
        {
            string[] configElements = null;
            x = -1;
            y = -1;
            direction = string.Empty;

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
    }
}
