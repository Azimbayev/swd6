using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 1;
        private Point _myHeadPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if(currentDirection == SnakeDirection.Up)
            {
                if (_myHeadPosition.Y == 1)
                {
                    return SnakeDirection.Left;
                }
            }

            if(currentDirection == SnakeDirection.Right)
            {
                if (_myHeadPosition.Y == _width - 2 && _myHeadPosition.X == _width - 2)
                {
                    return SnakeDirection.Up;
                }
                else if (_myHeadPosition.X == _wallDistanceThreshold)
                {
                    return SnakeDirection.Up;
                }
                else if (_myHeadPosition.X == _width - 3 && _myHeadPosition.Y != _width - 2)
                {
                    return SnakeDirection.Down;
                }
            }

            if(currentDirection == SnakeDirection.Down)
            {
                if (_myHeadPosition.Y % 2 == 0)
                {
                    return SnakeDirection.Right;
                }
                else
                {
                    return SnakeDirection.Left;
                }
            }

            if (currentDirection == SnakeDirection.Left)
            {
                if (_myHeadPosition.X == _wallDistanceThreshold)
                {
                    return SnakeDirection.Down;
                }
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
