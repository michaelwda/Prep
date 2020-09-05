using System.Collections.Generic;
using System.Linq;

namespace Prep.Tests.cut_off_trees_for_golf_event
{
    //https://leetcode.com/problems/cut-off-trees-for-golf-event/
    public class Solution
    {
        public int CutOffTree(IList<IList<int>> forest)
        {
            var treesToCut = new List<Tree>();
            for (var rowIndex = 0; rowIndex < forest.Count; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < forest[rowIndex].Count; columnIndex++)
                {
                    if (forest[rowIndex][columnIndex] > 1)
                    {
                        treesToCut.Add(new Tree() { Row = rowIndex, Column = columnIndex, Value = forest[rowIndex][columnIndex] });
                    }
                }
            }

            treesToCut.Sort((x, y) => x.Value.CompareTo(y.Value));

            var answer = 0;
            var searchRow = 0;
            var searchColumn = 0;
            foreach (var tree in treesToCut)
            {
                //Return the number of steps to reach the target tree
                int d = Steps(forest, searchRow, searchColumn, tree.Row, tree.Column);
                if (d < 0) return -1;
                answer += d;
                //Update our current Position
                searchRow = tree.Row;
                searchColumn = tree.Column;

            }

            return answer;

        }

        //BFS Search
        private int Steps(IList<IList<int>> forest, int beginRow, int beginColumn, int treeRow, int treeColumn)
        {

            var directions = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) };

            //If we're doing BFS, we can return immediately once we find it
            var rows = forest.Count;
            var columns = forest[0].Count;

            var workQueue = new Queue<SearchStep>();

            //Enqueue our current position with 0 steps taken
            workQueue.Enqueue(new SearchStep(beginRow, beginColumn, 0));

            //Mark first position as seen
            var seen = new bool[rows, columns];
            seen[beginRow, beginColumn] = true;

            //Iterate and refill queue
            while (workQueue.Any())
            {
                var current = workQueue.Dequeue();
                if (current.Row == treeRow && current.Column == treeColumn) return current.Steps;
                foreach (var dir in directions)
                {
                    var nextRow = current.Row + dir.Item1;
                    var nextColumn = current.Column + dir.Item2;
                    if (0 <= nextRow && nextRow < rows && 0 <= nextColumn && nextColumn < columns &&
                        !seen[nextRow, nextColumn] && forest[nextRow][nextColumn] > 0)
                    {
                        seen[nextRow, nextColumn] = true;
                        workQueue.Enqueue(new SearchStep(nextRow, nextColumn, current.Steps + 1));
                    }
                }
            }

            return -1;
        }
    }

    public class SearchStep
    {
        public SearchStep(int row, int column, int steps)
        {
            Row = row;
            Column = column;
            Steps = steps;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Steps { get; set; }
    }

    public class Tree
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }

    }



}
