using System.Collections.Generic;
using UnityEngine;

public class CellPool : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    private Stack<Cell> _pool = new Stack<Cell>();

    public Cell Get()
    {
        var cell = _pool.Count > 0 ? Pop() : Create();
        cell.gameObject.SetActive(true);
        return cell;
    }

    private Cell Pop()
    {
        return _pool.Pop();
    }

    private Cell Create()
    {
        return Instantiate(_prefab);
    }

    public void Push(Cell cell)
    {
        cell.Click = null;
        cell.AnimationEnd = null;
        cell.gameObject.SetActive(false);
        _pool.Push(cell);
    }

    public void Push(IEnumerable<Cell> cells)
    {
        foreach(var cell in cells)
        {
            Push(cell);
        }
    }
}
