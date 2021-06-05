using System;
using System.Collections.Generic;
using System.Drawing;

namespace MazeGenerator
{
    [Flags]
    public enum Wall
    {
        None = 0,
        Up = 1 << 0,
        Down = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
    }

    public class Cell
    {
        public static Wall OppositeWall(Wall wall)
        {
            return wall switch
            {
                Wall.Up => Wall.Down,
                Wall.Down => Wall.Up,
                Wall.Left => Wall.Right,
                Wall.Right => Wall.Left,
                _ => Wall.None
            };
        }

        public static Wall[] AdjacentWalls(Wall wall) => wall switch
        {
            Wall.Up or Wall.Down => new Wall[] { Wall.Left, Wall.Right },
            Wall.Left or Wall.Right => new Wall[] { Wall.Up, Wall.Down },
            _ => new Wall[] { }
        };

        private const int _kPointOffset = 3;
        private const int _kSizeOffset = _kPointOffset * 2;
        public Point position;
        public Size size;
        public Dictionary<Wall, Cell> Neighbords = new Dictionary<Wall, Cell>();
        public Wall Walls = Wall.None;
        public Color Color = Color.White;
        public Color VisitedColor = Color.Cyan;
        public bool HasBeenVisited = false;
        public bool ShouldDrawWalls = true;

        public Wall Doors = Wall.None;

        public Cell() { }

        public Cell(Cell cell, Color color)
        {
            this.position = cell.position;
            this.size = cell.size;
            this.Neighbords = cell.Neighbords;
            this.Walls = cell.Walls;
            this.Doors = cell.Doors;

            this.Color = color;
        }

        public void Draw(Pen pen, Graphics graphics)
        {
            if (HasBeenVisited)
            {
                graphics.FillRectangle(new SolidBrush(VisitedColor), new Rectangle(new Point(position.X + _kPointOffset, position.Y + _kPointOffset), new Size(size.Width - _kSizeOffset, size.Height - _kSizeOffset)));
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(Color), new Rectangle(new Point(position.X + _kPointOffset, position.Y + _kPointOffset), new Size(size.Width - _kSizeOffset, size.Height - _kSizeOffset)));
            }

            if (!ShouldDrawWalls)
            {
                return;
            }

            if (CheckWallDoor(Wall.Up))
            {
                graphics.DrawLine(pen,
                    position,
                    new Point(position.X + size.Width, position.Y));
            }

            if (CheckWallDoor(Wall.Down))
            {
                graphics.DrawLine(pen,
                    new Point(position.X, position.Y + size.Height),
                    new Point(position.X + size.Width, position.Y + size.Height));
            }

            if (CheckWallDoor(Wall.Left))
            {
                graphics.DrawLine(pen,
                    position,
                    new Point(position.X, position.Y + size.Height));
            }

            if (CheckWallDoor(Wall.Right))
            {
                graphics.DrawLine(pen,
                    new Point(position.X + size.Width, position.Y),
                    new Point(position.X + size.Width, position.Y + size.Height));
            }

            bool CheckWallDoor(Wall wall)
            {
                return Walls.HasFlag(wall) && !Doors.HasFlag(wall);
            }
        }

        public void AddWall(ref int depth, params Wall[] walls)
        {
            depth--;
            foreach (var wall in walls)
            {
                Walls |= wall;
                var secondDepth = depth;
                if (depth >= 0)
                {
                    var opositeWall = OppositeWall(wall);
                    if (Neighbords[wall] != null)
                    {
                        Neighbords[wall].AddWall(ref secondDepth, opositeWall);
                    }
                }
            }
        }

        public Cell Enter(Wall direction)
        {
            Doors |= OppositeWall(direction);
            var cell = this.Clone(Color.Orange);
            return cell;
        }

        public void Exit(Wall direction)
        {
            Doors |= direction;
            //var oWall = OppositeWall(direction);
            //if (!Doors.HasFlag(oWall))
            //{
            //    int depth = 1;
            //    AddWall(ref depth, oWall);
            //}

            var aWall = AdjacentWalls(direction);
            foreach (var wall in aWall)
            {
                if (!Doors.HasFlag(wall))
                {
                    int depth = 1;
                    AddWall(ref depth, wall);
                }
            }
        }

        public Cell Clone(Color color)
        {
            return new Cell(this, color);
        }
    }
}
