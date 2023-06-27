﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LegoAlgorithm
{
    internal class ChrisArrayList<T>
    {
        private T[] _items;
        private int _capacity;

        public ChrisArrayList()
        {
            Count = 0;
            _capacity = 4;
            _items = new T[_capacity];
        }

        public void Add(T value)
        {
            Resize();
            _items[Count++] = value;
        }

        public T Get(int index)
        {
            OutOfRangeIndex(index);
            Console.WriteLine(index);
            return _items[index];
        }

        public void InsertAt(int index, T value)
        {
            OutOfRangeIndex(index);
            Resize();
            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = value;
            Count++;
        }

        public bool Remove(T value)
        {
            var index = IndexOf(value);
            if (index == -1) return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            OutOfRangeIndex(index);
            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            Count--;
            _items[Count] = default;
        }

        public int Count { get; private set; }

        private void Resize()
        {
            if (Count == _items.Length)
            {
                T[] newArray = new T[_items.Length * 2];
                Array.Copy(_items, 0, newArray, 0, Count);
                _items = newArray;
            }
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
        }

        public void OutOfRangeIndex(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
        }

        public int IndexOf(T value)
        {
            for (var i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
                    return i;
            }
            return -1;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < Count; i++)
            {
                sb.Append(_items[i]);
                if (i < Count - 1) sb.Append(", ");
            }
            return sb.ToString();
        }

        public void BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var stopWatch = Stopwatch.StartNew();
            OutOfRangeIndex(startIndex);
            OutOfRangeIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            for (var i = startIndex; i < endIndex; i++)
                for (var j = startIndex; j < endIndex - i + startIndex; j++)
                    if (comparer.Compare(_items[j], _items[j + 1]) > 0)
                    {
                        var swap = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = swap;
                    }
            stopWatch.Stop();
            Console.WriteLine($"BubbleSort took: {stopWatch.Elapsed} seconds");
        }

        public void QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var stopWatch = Stopwatch.StartNew();
            OutOfRangeIndex(startIndex);
            OutOfRangeIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            QuickSortRecursive(startIndex, endIndex, comparer);
            stopWatch.Stop();
            Console.WriteLine($"QuickSort took: {stopWatch.Elapsed} seconds");
        }

        public void QuickSortRecursive(int start, int end, IComparer<T> comparer)
        {
            if (start < end)
            {
                var pivotIndex = Partition(start, end, comparer);
                QuickSortRecursive(start, pivotIndex - 1, comparer);
                QuickSortRecursive(pivotIndex + 1, end, comparer);
            }
        }

        public int Partition(int start, int end, IComparer<T> comparer)
        {
            var pivot = _items[end];
            var i = start - 1;

            for (var j = start; j < end; j++)
                if (comparer.Compare(_items[j], pivot) < 0)
                {
                    i++;
                    var swap = _items[i];
                    _items[i] = _items[j];
                    _items[j] = swap;
                }

            var swap2 = _items[i + 1];
            _items[i + 1] = _items[end];
            _items[end] = swap2;

            return i + 1;
        }

        public bool LinearSearch(T value, int startIndex, int endIndex)
        {
            var stopWatch = Stopwatch.StartNew();
            OutOfRangeIndex(startIndex);
            OutOfRangeIndex(endIndex);

            for (var i = startIndex; i < endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
                {
                    stopWatch.Stop();
                    Console.WriteLine($"LinearSearch took: {stopWatch.Elapsed} seconds and found the ITEM");
                    return true;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"LinearSearch took: {stopWatch.Elapsed} seconds and didnt find the ITEM");
            return false;
        }

        public bool BinarySearch(T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var stopWatch = Stopwatch.StartNew();
            OutOfRangeIndex(startIndex);
            OutOfRangeIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            while (startIndex <= endIndex)
            {
                var middleIndex = startIndex + (endIndex - startIndex) / 2;
                var compareResult = comparer.Compare(_items[middleIndex], value);

                if (compareResult == 0)
                {
                    stopWatch.Stop();
                    Console.WriteLine($"BinarySearch took: {stopWatch.Elapsed} seconds and DID find the item");
                    return true;
                }

                if (compareResult < 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }
            stopWatch.Start();
            Console.WriteLine($"BinarySearch took: {stopWatch.Elapsed} seconds and DIDNT find the item");
            return false;
        }
    }
}
