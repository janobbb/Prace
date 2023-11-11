using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public partial class GameController
    {
        private static GameController instance;
        int[,] array;
        public int moveCount;
        public List<int> results = new List<int>();
        public GameController()
        {
            array = new int[3,3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        }

        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        public int[,] GenerateRandomArray()
        {
            moveCount = 0;
            List<int> uniqueNumbers = Enumerable.Range(0, 9).ToList();
            Random rand = new Random();
            array = new int[3, 3];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int index = rand.Next(0, uniqueNumbers.Count);
                    array[i, j] = uniqueNumbers[index];
                    uniqueNumbers.RemoveAt(index);
                }
            }
            return array;
        }
        public int[,] GetArray()
        {
            return array;
        }

        public List<int> GetResults()
        {
            results.Sort();
            if(results.Count == 11 )
            {
                results.RemoveAt(results.Count-1);
            }
            return results;
        }
        public void Switch(int x1, int y1, int x2, int y2)
        {
            if (x1 != -1 && x2 != -1 && y1 != -1 && y2 != -1)
            {
                int temp = array[x1, y1];
                array[x1, y1] = array[x2, y2];
                array[x2, y2] = temp;
                moveCount++;
            }
        }
        public bool Win()
        {
            return array[0, 0] == 1
                && array[0, 1] == 2
                && array[0, 2] == 3
                && array[1, 0] == 4
                && array[1, 1] == 5
                && array[1, 2] == 6
                && array[2, 0] == 7
                && array[2, 1] == 8
                && array[2, 2] == 0;
        }
    }
}
