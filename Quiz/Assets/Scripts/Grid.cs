using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public void BuildGrid(List<Transform> elements, Vector2Int size)
    {
        if(elements.Count != size.x * size.y)
        {
            throw new System.ArgumentException("Number of elements does not match the size of the grid");
        }

        for (int x = 0, index = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++, index++)
            {
                elements[index].position = new Vector3(x - size.x / 2, y - size.y / 2, 0) * 3;
            }
        }
    }
}
