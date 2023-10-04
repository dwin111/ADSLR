using System;
using System.Diagnostics;

namespace SelectionSort
{
	public static class ShellSort
	{

        public static async Task<SortResponce<double>> Shell(this List<double> array)
        {
            var sw = new Stopwatch();
            List<double> arrayClone = new();
            List<string> step = new();
            arrayClone.AddRange(array);
            sw.Start();
            List<double> sortArray = await ShellSortDouble(array);
            sw.Stop();
            if (array.Count() <= 100)
            {
                step = await ShellSortStep(arrayClone);
            }
            return new SortResponce<double>() { Array = sortArray, ExecutionTime = sw.Elapsed, ArrayStep = step };
        }

        //метод обміну елементів
        public static void Swap<T>(ref List<T> array, int indexA, int indexB)
        {
            var temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }

        private static async Task<List<double>> ShellSortDouble(List<double> array)
        {
            //відстань між елементами, які порівнюються
            var d = array.Count() / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Count(); i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array, j, j - d);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        private static async Task<List<string>> ShellSortStep(List<double> array)
        {

            List<string> stepArray = new();
            //відстань між елементами, які порівнюються
            var d = array.Count() / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Count(); i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array, j, j - d);
                        j = j - d;
                    }
                }

                d = d / 2;
                stepArray.Add(await array.ArrayToString());
            }
            return stepArray;
        }



    }
}

