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

    //public delegate void OnStatChanged();
    //public OnStatChanged OnStatChangedCallback;

    public PlayerMovementBehaviour movement;
    private GameObject DialogHitbox;
    private GameObject Weapon;

    public EquiptmentInventory Eq;

    private SpriteRenderer sprRenderer;

    override protected void init(){
        DialogHitbox = transform.Find("hb_dialog").gameObject;
        Weapon = transform.Find("Weapon").gameObject;
        movement = GetComponent<PlayerMovementBehaviour>();

        Eq = new EquiptmentInventory();
        Eq.OnEquipChangedCallback += updateStats;
        sprRenderer = transform.Find("spr_player").GetComponent<SpriteRenderer>();
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
        DmgBehav.DealPoisonDamage(3);
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
    }

    private void OnTriggerStay2D(Collider2D collision) {
        AttackBehaviour atk = collision.GetComponentInParent<AttackBehaviour>();
        if(atk != null) {
            if (atk.isAttacking()) {
                sprRenderer.color = Color.red;
            } else {
                sprRenderer.color = Color.blue;
            }
        }
    }

}
