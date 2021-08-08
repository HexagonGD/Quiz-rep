using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemBandle", menuName = "Quiz/ItemBandle")]
public class ItemBundleData : ScriptableObject
{
    [SerializeField] private List<Item> _itemData;

    public IReadOnlyList<Item> ItemData => _itemData;
}
