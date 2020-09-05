using System.Collections.Generic;
using System.Linq;

//https://leetcode.com/problems/rotting-oranges/
namespace Prep.Tests.rotting_oranges
{
    public class Solution
    {
        public int OrangesRotting(int[][] grid)
        {
            //Empty Grid passed in
            if (grid.Length == 0)
                return -1;
            if (grid[0].Length == 0)
                return -1;

            var rottenOranges=new Queue<(int, int)>();
            var freshOrangesLeft = 0;
            for (var row = 0; row < grid.Length; row++)
            {
                for (var column = 0; column < grid[0].Length; column++)
                {
                    var orange = GetOrange(grid, row, column);
                    //Build my queue
                    if (orange == 1)
                    {
                        freshOrangesLeft++;
                    }
                    else if (orange == 2)
                    {
                        rottenOranges.Enqueue((row, column));
                    }

                }
            }

            //Using -1 as a tombstone indicating that we've reached the end of a level
            rottenOranges.Enqueue((-1,-1));

            //BFS
            int minutes = -1;
            while (rottenOranges.Any())
            {
                var rottenOrange = rottenOranges.Dequeue();
                //We've hit a tombstone
                if (rottenOrange.Item1 == -1)
                {
                    minutes++;
                    //We have another level of items to process, add another tombstone
                    if (rottenOranges.Any())
                    {
                        rottenOranges.Enqueue((-1, -1));
                    }
                }
                else
                {
                    //We should use a for loop here instead of repeating code...
                    //Rot neighbors
          
                    if (GetOrange(grid, rottenOrange.Item1 - 1, rottenOrange.Item2) == 1)
                    {
                        grid[rottenOrange.Item1 - 1][rottenOrange.Item2] = 2;
                        freshOrangesLeft--;
                        rottenOranges.Enqueue((rottenOrange.Item1 - 1, rottenOrange.Item2));
                    }
                    if (GetOrange(grid, rottenOrange.Item1 + 1, rottenOrange.Item2) == 1)
                    {
                        grid[rottenOrange.Item1 + 1][rottenOrange.Item2] = 2;
                        freshOrangesLeft--;
                        rottenOranges.Enqueue((rottenOrange.Item1 + 1, rottenOrange.Item2));
                    }
                    if (GetOrange(grid, rottenOrange.Item1, rottenOrange.Item2 + 1) == 1)
                    {
                        grid[rottenOrange.Item1][rottenOrange.Item2 + 1] = 2;
                        freshOrangesLeft--;
                        rottenOranges.Enqueue((rottenOrange.Item1, rottenOrange.Item2 + 1));
                    }
                    if (GetOrange(grid, rottenOrange.Item1, rottenOrange.Item2 - 1) == 1)
                    {
                        grid[rottenOrange.Item1][rottenOrange.Item2 - 1] = 2;
                        freshOrangesLeft--;
                        rottenOranges.Enqueue((rottenOrange.Item1, rottenOrange.Item2 - 1));
                    }
                }
            }

            if (freshOrangesLeft == 0)
            {
                return minutes;
            }
            else
            {
                return -1;
            }
             

        }

        public int GetOrange(int[][] grid, int row, int column)
        {
            if (grid.Length == 0)
                return 0;
            if (row < 0 || column < 0)
                return 0;
            if (row >= grid.Length)
                return 0;
            if (column >= grid[0].Length)
                return 0;
            return grid[row][column];
        }
    }

      
}
