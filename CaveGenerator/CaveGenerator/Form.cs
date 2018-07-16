﻿using Cave.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cave
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

            var dataSource = new List<CaveGenerator.Model.Algorithm>();

            dataSource.Add( new CaveGenerator.Model.Algorithm() { Name = "Simple Cave", Tag = "sc" });
            dataSource.Add( new CaveGenerator.Model.Algorithm() { Name = "Game of life", Tag = "gol" });

            this.algorithmComboBox.DataSource = dataSource;
            this.algorithmComboBox.DisplayMember = "Name";
            this.algorithmComboBox.ValueMember = "Tag";
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Boolean[,] caveCell = cave._celullarMap;

            Graphics g = e.Graphics;
            int cellSize = 10;
            Pen p = new Pen(Color.Black);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Rectangle activeCell;

            for (int y = 0; y < Utility.WIDTH + 1; ++y) {
                g.DrawLine(p, 0, y * cellSize, Utility.WIDTH * cellSize, y * cellSize);
            }

            for (int x = 0; x < Utility.HEIGTH + 1; ++x) {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, Utility.HEIGTH * cellSize);
            }

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!caveCell[x, y]) {
                        activeCell = new Rectangle(x * cellSize, y * cellSize, 10, 10);
                        e.Graphics.FillRectangle(greenBrush, activeCell);
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
            }
            cave = algoStrategy.InitializeCave(new Cave());
            this.Canvas.Invalidate();
        }
    }
}