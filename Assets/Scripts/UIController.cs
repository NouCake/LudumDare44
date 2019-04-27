using UnityEngine;
using System.Collections;
using TMPro;

public class UIController : MonoBehaviour {

    private static UIController ui;
    public static UIController get() {
        return ui;
    }

    void Awake() {
        if (ui != null) {
            Debug.Log("Too Many UIController");
            return;
        }
        ui = this;
    }

    public TextMeshProUGUI caption;
       
    void Start() {
        caption.text = "- None -";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setDialogCaption(string name)
    {
        caption.text = "- " + name + " -";
    }

}
