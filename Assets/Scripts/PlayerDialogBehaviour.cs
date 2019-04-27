using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogBehaviour : MonoBehaviour {

    private BoxCollider2D collider;

    void Start() {
        collider = transform.Find("hb_dialog").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collider.IsTouching(collision)) {
            UIController.get().setDialogCaption(collision.name);
            Debug.Log(collision.transform.name);
        }
    }

}
