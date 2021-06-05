using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        private const int _kCellSize = 25;
        private Cell[,] _cells;
        private Cell walker;
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitializeCells();
            _cells[0, 0].HasBeenVisited = true;
            walker = _cells[0, 0].Clone(Color.Orange);
            walker.ShouldDrawWalls = false;
        }

        private void InitializeCells()
        {
            _cells = new Cell[10, 10];
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _cells[x, y] = new Cell()
                    {
                        position = new Point(_kCellSize * x, _kCellSize * y),
                        size = new Size(_kCellSize, _kCellSize),
                    };
                }
            }

            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    if (y != 0)
                    {
                        _cells[x, y].Neighbords[Wall.Up] = _cells[x, y - 1];
                    }
                    else
                    {
                        _cells[x, y].Neighbords[Wall.Up] = null;
                    }

                    if (y != _cells.GetLength(0) - 1)
                    {
                        _cells[x, y].Neighbords[Wall.Down] = _cells[x, y + 1];
                    }
                    else
                    {
                        _cells[x, y].Neighbords[Wall.Down] = null;
                    }

                    if (x != 0)
                    {
                        _cells[x, y].Neighbords[Wall.Left] = _cells[x - 1, y];
                    }
                    else
                    {
                        _cells[x, y].Neighbords[Wall.Left] = null;
                    }

                    if (x != _cells.GetLength(1) - 1)
                    {
                        _cells[x, y].Neighbords[Wall.Right] = _cells[x + 1, y];
                    }
                    else
                    {
                        _cells[x, y].Neighbords[Wall.Right] = null;
                    }
                }
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            int depth = 1;
            _cells[1, 1].AddWall(ref depth, Wall.Down);
            BoardPanel.Refresh();
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Black, 5);
            var graphics = e.Graphics;

            foreach (var cell in _cells)
            {
                cell.Draw(pen, graphics);
            }
            walker.Draw(pen, graphics);
        }

        private void WalkButton_Click(object sender, EventArgs e)
        {
            Cell neighboard = null;
            var directions = new List<Wall>() { Wall.Up, Wall.Down, Wall.Left, Wall.Right };
            Wall direction = Wall.None;
            do
            {
                if (directions.Count == 0)
                {
                    walker.Color = Color.Red;
                    BoardPanel.Refresh();
                    return;
                }

                direction = directions[_random.Next(0, directions.Count)];
                directions.Remove(direction);
                neighboard = walker.Neighbords[direction];
            } while (neighboard == null || neighboard.HasBeenVisited);

            walker.Exit(direction);
            walker = neighboard.Enter(direction);
            walker.ShouldDrawWalls = false;
            neighboard.HasBeenVisited = true;

            BoardPanel.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Init();
            BoardPanel.Refresh();
        }
    }
}
