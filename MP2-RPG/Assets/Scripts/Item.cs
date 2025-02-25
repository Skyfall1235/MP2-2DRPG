using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string ItemName;
    public enum ItemType
    {
        None,
        key,
        consumable
    }
    public ItemType Type;
    public GameObject Prefab;

}
