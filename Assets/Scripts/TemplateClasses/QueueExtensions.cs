using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class QueueExtensions
{
    public static Queue<T> Shuffle<T>(this Queue<T> queue)
    {
        var list = queue.ToList();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }

        return new Queue<T>(list);
    }
}