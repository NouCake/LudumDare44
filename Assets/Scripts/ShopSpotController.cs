using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpotController : MonoBehaviour {

    public Equipment ToSell;

    private SpriteRenderer image;
    private DialogInterface dia;

    void Start() {
        image = transform.Find("spr_item").GetComponent<SpriteRenderer>();
        dia = GetComponent<DialogInterface>();
        image.sprite = ToSell.image;
        dia.DialogName = ToSell.name;
    }

    public void OnDialog() {
        PlayerController player = PlayerController.get();
        if (player.Eq.AddEquip(ToSell)) {
            Debug.Log("I just was bought");
            image.gameObject.SetActive(false);
        }
    }
}
