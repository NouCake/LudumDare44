using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogBehaviour : MonoBehaviour {

    private BoxCollider2D hitbox;

    void Start() {
        hitbox = transform.Find("hb_dialog").GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (hitbox.IsTouching(collision)) {
            UIController.get().setDialogCaption(collision.name);
            Debug.Log(collision.transform.name);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIController.get().setDialogCaption("None");

    }

}
