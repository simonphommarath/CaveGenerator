using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaveGenerator
{
    public partial class Form : System.Windows.Forms.Form
    {
        CaveGenerator cave;

        public Form()
        {

            cave = new CaveGenerator();
            cave.InitializeCave();
            //cave.DoSimulation2();
            //cave.PrintGrid();
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Boolean[,] caveCell = cave.GetCellularMap();

            Graphics g = e.Graphics;
            int cellSize = 10;
            Pen p = new Pen(Color.Black);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Rectangle activeCell;

            for (int y = 0; y < cave.GetWidth() + 1; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, cave.GetWidth() * cellSize, y * cellSize);
            }

            for (int x = 0; x < cave.GetHeigth() + 1; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, cave.GetHeigth() * cellSize);
            }


            for (int x = 0; x < cave.GetWidth(); x++)
            {
                for (int y = 0; y < cave.GetHeigth(); y++)
                {
                    if (caveCell[x, y])
                    {
                        activeCell = new Rectangle(x * cellSize, y * cellSize, 10, 10);
                        e.Graphics.FillRectangle(greenBrush, activeCell);
                        g.DrawRectangle(p, activeCell);
                    }
                }
            }
        }

        private void iterationButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cave.GetIterationCount(); i++) {
                cave.DoSimulation2();
            }

            this.Canvas.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            cave.InitializeCave();
            this.Canvas.Invalidate();
        }

        private void singleIterationButton_Click(object sender, EventArgs e)
        {
            cave.DoSimulation2();
            this.Canvas.Invalidate();
        }
    }
}
