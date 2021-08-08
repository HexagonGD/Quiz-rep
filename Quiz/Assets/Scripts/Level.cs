using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public enum LevelState
{
    Play,
    Complete
}

public class Level
{
    private CellPool _pool;
    private Cell[] _cells;
    private Cell _answer;
    private LevelState _levelState = LevelState.Play;

    public Action Complete;

    public string Quest => _answer.Identifier;

    public Level(Vector2Int sizeLevel, bool startLevel, List<Item> data, CellPool pool)
    {
        var size = sizeLevel.x * sizeLevel.y;
        _cells = new Cell[size];
        _pool = pool;

        for (int i = 0; i < size; i++)
        {
            _cells[i] = pool.Get();
            _cells[i].Click += OnClickCell;
            _cells[i].SetItem(data[i]);
        }

        _answer = _cells[Random.Range(0, size)];

        var grid = new Grid();
        grid.BuildGrid(_cells.Select(x => x.transform).ToList(), sizeLevel);

        if(startLevel)
        {
            DoBounceCells();
        }
    }

    private void DoBounceCells()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].DoBounce();
        }
    }

    private void OnClickCell(Cell cell)
    {
        if(_levelState == LevelState.Complete)
        {
            return;
        }

        if (cell == _answer)
        {
            _levelState = LevelState.Complete;
            cell.DoBounceItem();
            cell.AnimationEnd += LevelComplete;
        }
        else
        {
            cell.DoShake();
        }
    }

    private void LevelComplete()
    {
        foreach (var item in _cells)
        {
            _pool.Push(item);
        }
        Complete?.Invoke();
        Complete = null;
    }
}
