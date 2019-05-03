using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogInterface : MonoBehaviour {
    //Unity enum dropbox
    public int type = 0;
    public string DialogName = "Fred";
    public UnityEvent OnDialog;
    public Collider2D DialogHitbox;

    private void Awake() {
        if(DialogHitbox == null) {
            DialogHitbox = transform.Find("hb_dialog").GetComponent<Collider2D>();
        }
    }

}
