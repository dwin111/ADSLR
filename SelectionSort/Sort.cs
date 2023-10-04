using System.Diagnostics;

namespace SelectionSort
{
    public static class Sort
    {
        public static double[,] SelectionSortMatrix(double[,] matrix, int n, int m)
        {
            try
            {
                double temp;
                int smallest;
                for (int i = 0; i < n - 1; i++)
                {
                    smallest = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (matrix[0, j] < matrix[0, smallest])
                        {
                            smallest = j;
                        }
                    }
                    for (int h = 0; h < m; h++)
                    {
                        temp = matrix[h, smallest];
                        matrix[h, smallest] = matrix[h, i];
                        matrix[h, i] = temp;
                    }

                }
                return matrix;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        public static async Task<SortResponce<double>> Selection(this List<double> array)
        {
            var sw = new Stopwatch();
            List<double> arrayClone = new();
            List<string> step = new();
            arrayClone.AddRange(array);
            sw.Start();
            List<double> sortArray = SelectionSortDouble(array);
            sw.Stop();
            if (array.Count() <= 100)
            {
                step = await SelectionSortStep(arrayClone);
            }
            return new SortResponce<double>() { Array = sortArray, ExecutionTime = sw.Elapsed, ArrayStep = step };
        }
        private static List<double> SelectionSortDouble(List<double> array)
        {
            double temp;
            int smallest;
            for (int i = 0; i < array.Count - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }
            return array;
        }
        private static async Task<List<string>> SelectionSortStep(List<double> array)
        {

            List<string> stepArray = new();
            double temp;
            int smallest;
            for (int i = 0; i < array.Count - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
                stepArray.Add(await array.ArrayToString());
            }
            return stepArray;
        }
        public static async Task<string> ArrayToString<T>(this List<T> array)
        {
            string temp = "";
            Parallel.ForEach(array, item =>
            {
                temp += item.ToString() + ", ";
            });
            return temp;
        }
    }
}

