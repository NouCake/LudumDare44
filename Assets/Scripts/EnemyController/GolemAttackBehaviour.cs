using UnityEngine;

public class GolemAttackBehaviour : AttackBehaviour {

    public float ChargeTime = 0.5f;
    public float MinChargeTime = 0.2f;
    public float MinDistancePlayer = 1;
    private float chargeTimer;
    private PlayerController player;
    private DamageableInformation info;

    #region placeholder
    private SpriteRenderer sprRenderer;
    private Transform Weapon;
    #endregion

    protected override void init() {
        player = PlayerController.get();
        chargeTimer = ChargeTime;
        sprRenderer = transform.Find("spr_enemy").GetComponent<SpriteRenderer>();
        Weapon = transform.Find("Weapon");
        chargeTimer = 0;
        info = new DamageableInformation(controller, transform, controller.TotalStats);
        Weapon.gameObject.SetActive(false);
    }

    override protected void InitHitbox() {
        attackHitbox = transform.Find("hb_damage").GetComponent<Collider2D>();
    }

    protected override bool AttackCondition() {
        if(Vector2.Distance(transform.position, player.transform.position) < MinDistancePlayer) {
            if (chargeTimer <= 0) {
                OnChargeStart();
            }
        } else {
            if(chargeTimer > MinChargeTime) {
                OnChargeAbort();
            }
        }

        if (chargeTimer > 0){
            chargeTimer -= Time.deltaTime;
            if(chargeTimer < MinChargeTime) {
                OnMinCharge();
            }
            if (chargeTimer <= 0) {
                //OnChargeEnd();
                return true;
            }
        }

        return false;
    } 

    private void OnChargeStart() {
        chargeTimer = ChargeTime;
        int angle = MyUtility.GetAxisOrientedAngle(player.transform.position - transform.position);
        attackHitbox.transform.localEulerAngles = Vector3.forward * (angle + 90);
        Weapon.transform.localEulerAngles = Vector3.forward * (angle + 90);
    }

    private void OnChargeAbort() {
        chargeTimer = 0;
        controller.SetMoveInputBlocked(false); //Line should be redundant
    }

    private void OnMinCharge() {
        sprRenderer.color = Color.yellow;
        controller.SetMoveInputBlocked(true);
    }

    protected override void OnAttackStart() {
        Weapon.gameObject.SetActive(true);
    }

    protected override void OnAttackEnd() {
        sprRenderer.color = Color.gray;
        controller.SetMoveInputBlocked(false);
        Weapon.gameObject.SetActive(false);
    }

    protected override void DealDamage(CharController target) {
        target.DmgBehav.DealPhysicalDamage(info);
    }

}
