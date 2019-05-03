using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpotController : MonoBehaviour {

    public Item ToSell;

    private SpriteRenderer image;
    private DialogInterface dia;

    void Start() {
        image = transform.Find("spr_item").GetComponent<SpriteRenderer>();
        dia = GetComponent<DialogInterface>();
        image.sprite = ToSell.image;
        dia.DialogName = ToSell.name;
    }

    public void OnDialog() {
        Debug.Log("I just was bought");
        image.gameObject.SetActive(false);
    }
}
