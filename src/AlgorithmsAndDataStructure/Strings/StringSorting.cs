using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings;


public class MostSignificantDigitStringSorting
{
    private static int R = 256;
    private static int CUTOFF = 15;
    private static string[] _aux;

    private static int CharAt(string s, int d)
    {
        if (d < s.Length)
            return s[d];
        else
            return -1;
    }
    public static void Sort(string[] data)
    {
        int n = data.Length;
        _aux = new string[n];
        Sort(data, 0, n - 1, 0);
    }

    public static void Sort(string[] data, int low, int high, int digit)
    {
        // Recommended to add the cutoff number for insertion sort
        //if (high <= low + CUTOFF)
        //{
        //          InsertionSort(data, low, high, digit);
        //          return data;
        //      }

        var count = new int[R + 2];
        for (int i = low; i <= high; i++)
        {
            count[CharAt(data[i], digit) + 2]++;
        }

        for (int i = 0; i < count.Length - 1; i++)
            count[i + 1] += count[i];

        for (var i = low; i <= high; i++)
        {
            var currentChar = CharAt(data[i], digit);
            _aux[count[currentChar + 1]++] = data[i];
        }

        for (int i = low; i <= high; i++)
        {
            data[i] = _aux[i - low];
        }

        for (int r = 0; r < R; r++)
            Sort(data, low + count[r], low + count[r + 1] - 1, digit + 1);

        return;
    }
}

public class KeyIndexedSorting
{
    public static string[] Sort(string[] data, int w)
    {
        if (w == 0)
            return data;

        var r = 256; // Characters in the ASCII table
        var count = new int[r + 1];
        var n = data.Length;

        // Calculate the count 
        for (int i = 0; i < data.Length; i++)
        {
            var currentChar = (int)data[i][w - 1];
            count[currentChar + 1]++;
        }

        // Calculate the frequencies
        for (int i = 0; i < count.Length - 1; i++)
        {
            count[i + 1] += count[i];
        }

        // Distribute the data 
        var aux = new string[n];
        for (int i = 0; i < aux.Length; i++)
        {
            var currentChar = (int)data[i][w - 1];
            aux[count[currentChar]++] = data[i];
        }

        for (int i = 0; i < aux.Length; i++)
        {
            data[i] = aux[i];
        }

        return Sort(data, w - 1);
    }
}
