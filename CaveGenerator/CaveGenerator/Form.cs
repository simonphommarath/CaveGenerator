using CaveGenerator;
using CaveGenerator.Algorithm;
using CaveGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaveGenerator
{
    public partial class Form : System.Windows.Forms.Form
    {
        Cave cave;
        IProceduralGenStragery algoStrategy; 

        public Form()
        {
            this.SetProceduralGenStrategy(new SimpleCaveStrategy());
            cave = algoStrategy.InitializeCave(new Cave());
            InitializeComponent();

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
            Cell[,] caveCell = cave._celullarMap;

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
                    if (caveCell[x, y].state != Utility.STATE.Air)
                    {
                        activeCell = new Rectangle(x * cellSize, y * cellSize, 10, 10);
                        if (caveCell[x, y].state == Utility.STATE.Rock) {
                            brush = new SolidBrush(Color.Gray);
                            e.Graphics.FillRectangle(brush, activeCell);
                        }
                        else if (caveCell[x, y].state == Utility.STATE.Seed) {
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

        void SetProceduralGenStrategy(IProceduralGenStragery strategy)
        {
            algoStrategy = strategy;
        }


        private void iterationButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < algoStrategy._iterationCount; i++) {
                cave = algoStrategy.doSimulation(cave);
            }
            this.Canvas.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            cave.MakeBlankGrid();
            cave = algoStrategy.InitializeCave(new Cave());
            this.Canvas.Invalidate();
        }

        private void singleIterationButton_Click(object sender, EventArgs e)
        {
            cave = algoStrategy.doSimulation(cave);
            this.Canvas.Invalidate();
        }

        private void algorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.algorithmComboBox.SelectedValue)
            {
                case "sc":
                    this.SetProceduralGenStrategy(new SimpleCaveStrategy());
                    break;
                case "gol":
                    this.SetProceduralGenStrategy(new GameOfLifeStrategy());
                    break;
                case "op":
                    this.SetProceduralGenStrategy(new OpenPlatformStrategy());
                    break;
                case "sta":
                    this.SetProceduralGenStrategy(new StalagmiteStrategy());
                    break;
                case "pla":
                    this.SetProceduralGenStrategy(new PlantStrategy());
                    break;
                case "flo":
                    this.SetProceduralGenStrategy(new FloorLevelStrategy());
                    break;
            }
            cave = algoStrategy.InitializeCave(new Cave());
            this.Canvas.Invalidate();
        }
    }
}