using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        String[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);
        long[] arr = new long[n];
        long[] tree = new long[n * 4];
        for (int i = 0; i < n; i++)
            arr[i] = long.Parse(Console.ReadLine());
        TreeMul mul = new TreeMul(arr, tree);
        mul.init_mul(0, n - 1, 1);
        for (int i = 0; i < m + k; i++)
        {
            String[] tmp = Console.ReadLine().Split();
            switch (tmp[0])
            {
                case "1":
                    mul.update(0, n - 1, 1, int.Parse(tmp[1]) - 1, long.Parse(tmp[2]), arr[long.Parse(tmp[1]) - 1]);
                    arr[long.Parse(tmp[1]) - 1] = long.Parse(tmp[2]);
                    break;
                case "2":
                    sb.Append((mul.mul(0, n - 1, 1, int.Parse(tmp[1]) - 1, int.Parse(tmp[2]) - 1)) + "\n");
                    break;
            }
        }
        Console.WriteLine(sb);
    }
}
class TreeMul   //노드의 곱 세그먼트 트리
{
    long[] arr;
    long[] tree;
    public TreeMul(long[] arr, long[] tree)
    {
        this.arr = arr;
        this.tree = tree;
    }
    //트리 만들기) start: 시작 인덱스 end: 마지막 인덱스 node: 트리의 시작 (1)
    public long init_mul(int start, int end, int node)
    {
        if (start == end)
        {
            tree[node] = arr[start];
            return tree[node];
        }
        int mid = (start + end) / 2;
        tree[node] = (init_mul(start, mid, node * 2) * init_mul(mid + 1, end, node * 2 + 1)) % 1000000007;
        return tree[node];
    }
    //곱 구하기) left, right:범위
    public long mul(int start, int end, int node, int left, int right)
    {
        if (left > end || right < start)
            return 1;   //1을곱함=변화없음
        if (left <= start && right >= end)
            return tree[node];
        int mid = (start + end) / 2;
        return (mul(start, mid, node * 2, left, right) * mul(mid + 1, end, node * 2 + 1, left, right)) % 1000000007;
    }
    //값 수정하기) index: 변경할 인덱스 dif: 변경할 값 origin: 기존 값
    public void update(int start, int end, int node, int index, long dif, long origin)
    {
        if (index < start || index > end)
            return;
        try
        {
            tree[node] /= origin;
            tree[node] *= dif;
        }catch(Exception){tree[node]=dif;}
        if (start == end)
            return;
        int mid = (start + end) / 2;
        update(start, mid, node * 2, index, dif, origin);
        update(mid + 1, end, node * 2 + 1, index, dif, origin);
    }
}