using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    public string itemName;
    [Space(5f)]
    public GameObject itemPrefab;
    public Sprite itemPreview;
    [Space(5f)]
    public string info1;
    public string info2;
}

[CreateAssetMenu(fileName = "New App Settings", menuName = "App Settings")]
public class AppSettings : ScriptableObject
{
    [SerializeField] private ItemData[] items;

    public int ItemCount => items.Length;
    
    public ItemData GetItem(int i) => items[i];
    
}
