using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour {

    public Inventory inv;
    public GameObject ItemLine;

    private List<GameObject> lines;
    private int visibleCount;

    void Start() {
        lines = new List<GameObject>();
        inv.ItemChangedCallback += updateUI;
        updateUI();
    }

    private void removeAll() {
        for(int i = 0; i < lines.Count; i++) {
            lines[i].SetActive(false);
        }
        visibleCount = 0;
    }

    private void updateUI() {
        removeAll();
        List<Item> items = inv.GetItems();
        for (int i = 0; i < items.Count; i++) {
            addItem(items[i]);
        }
    }

    private void addItem(Item i) {
        GameObject line;
        if (visibleCount < lines.Count && lines[visibleCount] != null) {
            line = lines[visibleCount];
        } else {
            line = Instantiate(ItemLine, transform.Find("Content"));
            line.transform.localPosition = Vector3.down * 15 * visibleCount;
        }
        visibleCount++;
        initLine(line, i);
    }

    private void initLine(GameObject line, Item i) {
        line.transform.Find("ItemIcon").GetComponent<Image>().sprite = i.image;
        line.transform.Find("ItemLabel").GetComponent<TextMeshProUGUI>().text = i.name;
        line.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>().text = 1+"";
    }

}
