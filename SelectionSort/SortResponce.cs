using System;
namespace SelectionSort
{
	public class SortResponce<T>
	{
		public TimeSpan ExecutionTime { get; set; }
        public IEnumerable<T> Array { get; set; }
        public IEnumerable<string> ArrayStep { get; set; }
    }
}

