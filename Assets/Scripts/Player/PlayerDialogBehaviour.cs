using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogBehaviour : MonoBehaviour {

    private BoxCollider2D hitbox;
    private DialogInterface dialog;

    void Start() {
        hitbox = transform.Find("hb_dialog").GetComponent<BoxCollider2D>();
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) { 
            if(dialog != null) {
                dialog.OnDialog.Invoke();
            }
        }
    }

    private void OnDialogable(DialogInterface dia) {
        UIController.get().setDialogCaption(dia.DialogName);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "DialogHitbox") {
            if (hitbox.IsTouching(collision)) {
                DialogInterface i = collision.GetComponentInParent<DialogInterface>();
                if(i != null){
                    OnDialogable(i);
                    dialog = collision.GetComponentInParent<DialogInterface>();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (dialog != null && !hitbox.IsTouching(dialog.DialogHitbox)) {
            dialog = null;
            UIController.get().setDialogCaption("");
        }

    }

}
