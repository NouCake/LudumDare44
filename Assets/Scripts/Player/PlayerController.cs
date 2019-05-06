using UnityEngine;
using System.Collections;

public class PlayerController : CharController{

    #region singleton

    private static PlayerController singleton;
    public static PlayerController get() {
        return singleton;
    }
    private void Awake() {
        if(singleton != null)
        {
            Debug.Log("Too Many UIController");
            return;
        }
        singleton = this;
    }
    #endregion

    public PlayerMovementBehaviour movement;
    private GameObject DialogHitbox;
    private GameObject Weapon;

    public EquiptmentInventory Eq;
    

    override protected void init(){
        DialogHitbox = transform.Find("hb_dialog").gameObject;
        Weapon = transform.Find("Weapon").gameObject;
        movement = GetComponent<PlayerMovementBehaviour>();

        Eq = new EquiptmentInventory();
        Eq.OnEquipChangedCallback += updateStats;
    }

    override protected void ControllerUpdate() {
        int angle = MyUtility.GetAxisOrientedAngle(movement.direction);
        DialogHitbox.transform.localEulerAngles = Vector3.forward * angle;
        Weapon.transform.localEulerAngles = Vector3.forward * angle;
        if (Input.GetKeyDown(KeyCode.Space)) {
            CurTestFunction();
        }
    }

    private void CurTestFunction() {
    }

    private void updateStats() {
        TotalStats.SetAll(0);
        TotalStats.Add(BaseStats);
        TotalStats.Add(Eq.EquipStats);
    }

    public override void OnHit(Transform source) {
        base.OnHit(source);
        DmgBehav.SetInvincible(1);
        ScreenShaker.Shake(.2f, .1f);
        GetComponentInChildren<PlayerHittedAnimation>().StartAnimation();
    }

}
