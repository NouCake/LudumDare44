using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/New Inventory")]
public class Inventory : ScriptableObject {

    public delegate void ItemsChanged();
    public ItemsChanged ItemChangedCallback;

    public List<Item> items;

    public Inventory() {
        items = new List<Item>();
    }

    public List<Item> GetItems() {
        return items;
    }

}
