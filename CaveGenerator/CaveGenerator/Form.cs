using _2DProceduralContentGenerator;
using _2DProceduralContentGenerator.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2DGridDrawer
{
    public partial class Form : System.Windows.Forms.Form
    {
        private ProceduralContentGenerator generator;

        public Form()
        {
            InitializeComponent();

            generator = new ProceduralContentGenerator();
            var dataSource = new List<AlgorithmDataSource>();

            dataSource.Add( new AlgorithmDataSource() { Name = "Simple Cave", Tag = "sc" });
            dataSource.Add( new AlgorithmDataSource() { Name = "Game of life", Tag = "gol" }); 
            dataSource.Add( new AlgorithmDataSource() { Name = "Open Platform (L1)", Tag = "op" }); 
            dataSource.Add( new AlgorithmDataSource() { Name = "Stalag generation", Tag = "sta" });
            dataSource.Add( new AlgorithmDataSource() { Name = "Plant generation", Tag = "pla" });
            dataSource.Add( new AlgorithmDataSource() { Name = "Floor generation", Tag = "flo" });

            this.algorithmComboBox.DataSource = dataSource;
            this.algorithmComboBox.DisplayMember = "Name";
            this.algorithmComboBox.ValueMember = "Tag";
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellSize = 10;
            Pen p = new Pen(Color.Black);
            //p.Alignment = PenAlignment.Inset; //<-- this
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle activeCell;
            
            for (int y = 0; y < Utility.WIDTH + 1; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, Utility.WIDTH * cellSize, y * cellSize);
                g.DrawLine(p, y * cellSize, 0, y * cellSize, Utility.HEIGTH * cellSize);
            }

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (generator.cave._celullarMap[x, y].state != Utility.STATE.Air)
                    {
                        activeCell = new Rectangle(x * cellSize, y * cellSize, 10, 10);
                        if (generator.cave._celullarMap[x, y].state == Utility.STATE.Rock) {
                            brush = new SolidBrush(Color.Gray);
                            e.Graphics.FillRectangle(brush, activeCell);
                        }
                        else if (generator.cave._celullarMap[x, y].state == Utility.STATE.Seed) {
                            brush = new SolidBrush(Color.Green);
                            e.Graphics.FillRectangle(brush, activeCell);
                        }
                        else
                        {
                            brush = new SolidBrush(Color.Orange);
                            e.Graphics.FillRectangle(brush, activeCell);
                        }
                        g.DrawRectangle(p, activeCell);
                    }
                }
            }
        }

        private void iterationButton_Click(object sender, EventArgs e)
        {
            generator.DoIterationSimulation();
            this.Canvas.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            generator.Reset();
            this.Canvas.Invalidate();
        }

        private void singleIterationButton_Click(object sender, EventArgs e)
        {
            generator.DoSingleSimulation();
            this.Canvas.Invalidate();
        }

        private void algorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            generator.SetProceduralGenStrategy(this.algorithmComboBox.SelectedValue.ToString());
            this.Canvas.Invalidate();
        }
    }
}