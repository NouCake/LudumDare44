using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

    #region singleton

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

    #endregion

    public TextMeshProUGUI caption;
    public GameObject Slots;
       
    void Start() {
        caption.text = "";
    }

    public void setDialogCaption(string name) {
        caption.text = name;
    }

    public void FillSlot(Equipment eq) {
        Transform t = Slots.transform.Find("Slot " + eq.SlotType);
        t = t.Find("SlotForm");
        Image i = t.GetComponent<Image>();
        i.sprite = eq.image;
        i.color = Color.white;

    }

}
