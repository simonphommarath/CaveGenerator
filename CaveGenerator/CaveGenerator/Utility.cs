using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CaveGenerator
{
    public static class Utility
    {
        public enum STATE
        {
            Rock,
            Air,
            Other,
            Seed
        }

        public const int WIDTH = 130;
        public const int HEIGTH = 75;

        /// <summary>
        /// Print grid in text file (temp)
        /// </summary>
        public static void PrintGrid(Boolean[,] cave)
        {
            string path = @"D:\MyTest.txt";

            // Delete file
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            if (!File.Exists(path))
            {
                // Creates a file and write
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int x = 0; x < Utility.WIDTH; x++)
                    {
                        for (int y = 0; y < Utility.HEIGTH; y++)
                        {
                            sw.Write(cave[x, y] ? "#" : ".");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}