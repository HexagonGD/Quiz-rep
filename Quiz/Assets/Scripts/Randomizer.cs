using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Randomizer
{
    public static List<T> GetSomeRandomValues<T>(IList<T> values, int count)
    {
        if(values.Count < count)
        {
            throw new System.IndexOutOfRangeException();
        }

        var copyList = values.Select(x => x).ToList();
        var randomValues = new List<T>();
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, copyList.Count);
            randomValues.Add(copyList[index]);
            copyList.RemoveAt(index);
        }

        return randomValues;
    }
}
