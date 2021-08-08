using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private QuestUI _questUI;
    [SerializeField] private CellPool _pool;
    [SerializeField] private List<ItemBundleData> _itemBundles;
    [SerializeField] private List<Vector2Int> _levelSizes;

    private int _currentLevel;

    [SerializeField] private UnityEvent StartGame;
    [SerializeField] private UnityEvent EndGame;

    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        _currentLevel = 0;
        BuildLevel(_levelSizes[_currentLevel], true);
        StartGame?.Invoke();
    }

    private void BuildLevel(Vector2Int size, bool startLevel = false)
    {
        var bundle = _itemBundles[Random.Range(0, _itemBundles.Count)];
        var data = Randomizer.GetSomeRandomValues((IList<Item>)bundle.ItemData, size.x * size.y);
        var level = new Level(size, startLevel, data, _pool);
        level.Complete += OnLevelComplete;
        _questUI.SetQuest(level.Quest);
    }

    private void OnLevelComplete()
    {
        if (++_currentLevel < _levelSizes.Count)
        {
            BuildLevel(_levelSizes[_currentLevel]);
        }
        else
        {
            EndGame?.Invoke();
        }
    }
}