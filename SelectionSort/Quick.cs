using System;
using System.Diagnostics;
namespace SelectionSort
{
	public static class Quick
	{


        public static async Task<SortResponce<double>> QuickSortDouble(this List<double> array)
        {
            var sw = new Stopwatch();
            List<double> arrayClone = new();
            List<string> step = new();
            arrayClone.AddRange(array);
            sw.Start();
            List<double> sortArray = QuickSort(array.ToArray()).ToList();
            sw.Stop();
            //if (array.Count() <= 100)
            //{
            //    step = await ShellSortStep(arrayClone);
            //}
            return new SortResponce<double>() { Array = sortArray, ExecutionTime = sw.Elapsed, ArrayStep = step };
        }


        #region Algoritm
        //метод для обміну елементів масиву
        static void Swap(ref double x, ref double y)
        {
            var t = x;
            x = y;
            y = t;
        }
        //метод повертає індекс опорного елементу
        static int Partition(double[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        //швидке сортування
        static double[] QuickSort(double[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static double[] QuickSort(double[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        #endregion
        private static async Task<List<string>> QuickSortStep(List<double> array, int minIndex, int maxIndex)
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



    }

}

