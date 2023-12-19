using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ConsolApplicaton3
{
    class Program
    {
        static long[] arr;
        static long[] treeMin;
        static long[] treeMax;
        //static List<int> tree;
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            String[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int a, b;
            arr = new long[n];
            treeMin = new long[arr.Length * 4];
            treeMax = new long[arr.Length * 4];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            init_min(0, arr.Length - 1, 1);
            init_max(0, arr.Length - 1, 1);
            while (m > 0)
            {
                m--;
                String[] tmp = Console.ReadLine().Split();
                a = int.Parse(tmp[0]);
                b = int.Parse(tmp[1]);
                sb.Append(min(0, arr.Length - 1, 1, a - 1, b - 1)+" ");
                sb.Append(max(0, arr.Length - 1, 1, a - 1, b - 1) + "\n");
            }
            Console.WriteLine(sb);
        }
        static long init_min(int start, int end, int index)
        {
            if (start == end)
            {
                treeMin[index] = arr[start];
                return treeMin[index];
            }
            int mid = (start + end) / 2;
            treeMin[index] = Math.Min(init_min(start, mid, index * 2), init_min(mid + 1, end, index * 2 + 1));
            return treeMin[index];
        }
        static long min(int start, int end, int index, int left, int right)
        {
            if (left > end || right < start)
                return (int)1e9 + 1;
            if (left <= start && right >= end)
                return treeMin[index];
            int mid = (start + end) / 2;
            return Math.Min(min(start, mid, index * 2, left, right), min(mid + 1, end, index * 2 + 1, left, right));
        }
        static long init_max(int start, int end, int index)
        {
            if (start == end)
            {
                treeMax[index] = arr[start];
                return treeMax[index];
            }
            int mid = (start + end) / 2;
            treeMax[index] = Math.Max(init_max(start, mid, index * 2), init_max(mid + 1, end, index * 2 + 1));
            return treeMax[index];
        }
        static long max(int start, int end, int index, int left, int right)
        {
            if (left > end || right < start)
                return -1;
            if (left <= start && right >= end)
                return treeMax[index];
            int mid = (start + end) / 2;
            return Math.Max(max(start, mid, index * 2, left, right), max(mid + 1, end, index * 2 + 1, left, right));
        }
    }
}