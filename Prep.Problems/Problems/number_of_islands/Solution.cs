using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://leetcode.com/problems/number-of-islands/
namespace Prep.Problems.Problems.number_of_islands
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            if (grid.Length == 0)
                return 0;
            if (grid[0].Length == 0)
                return 0;

            var islandCount = 0;
            //Look for land
            for (var row = 0; row < grid.Length; row++)
            {
                for (var column = 0; column < grid[row].Length; column++)
                {
                    if (grid[row][column] == '1')
                    {
                        islandCount++;
                        //We've found undiscovered land, walk the entire island
                        WalkIsland(row, column, grid);
                    }
                }
            }

            return islandCount;
        }

        //Up, Right, Down, Left
        private readonly List<(int, int)> directions = new List<(int, int)>() { (-1, 0), (0, 1), (1, 0), (0, -1) };

        //Walks the entire island marking each piece of land with a 2 until it can't find any more tiles
        private void WalkIsland(int row, int column, char[][] grid)
        {
            if (row < 0 || row >= grid.Length || column < 0 || column >= grid[row].Length)
            {
                return;
            }
            if (grid[row][column] == '1')
            {
                grid[row][column] = '2';
                //Walk all directions       
                foreach (var direction in directions)
                {
                    WalkIsland(row + direction.Item1, column + direction.Item2, grid);
                }
            }
        }
    }

}
