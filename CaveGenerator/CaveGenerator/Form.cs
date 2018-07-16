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
            cave.DoSimulation();
            cave.PrintGrid();

            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Boolean[,] caveCell = cave.GetCellularMap();

            Graphics g = e.Graphics;
            int cellSize = 10;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < cave.GetWidth() + 1; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, cave.GetWidth() * cellSize, y * cellSize);
            }

            for (int x = 0; x < cave.GetHeigth() + 1; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, cave.GetHeigth() * cellSize);
            }
        }
    }
}
