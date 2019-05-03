using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
    
    public DamageBehaviour dmgBehav;
    public KnockbackBehaviour knockBehav;
    public HealthController health; //Hide in Inspector

    protected EquiptmentInventory equip;

    public Stats BaseStats;
    public Stats TotalStats;

    protected Rigidbody2D body;

    private bool moveInput;

    void Start() {
        health = GetComponent<HealthController>();
        knockBehav = GetComponent<KnockbackBehaviour>();
        body = GetComponent<Rigidbody2D>();

        moveInput = true;
        dmgBehav = new DamageBehaviour(this);
        BaseStats = new Stats(5, 5);
        BaseStats.maxhealth = health.MaxHealth;
        TotalStats = new Stats(BaseStats);
        equip = new EquiptmentInventory();

        init();
    }

    private void Update() {
        dmgBehav.UpdateEffects(Time.deltaTime);
        ControllerUpdate();
    }

    protected virtual void ControllerUpdate() {

    }

    protected virtual void init() {
    }

    protected void updateStats() {
        TotalStats.SetAll(0);
        TotalStats.Add(BaseStats);
        TotalStats.Add(equip.EquipStats);
    }

    public bool IsMoveInputBlocked() {
        return moveInput;
    }


    public bool IsMoveBlocked() {
        return knockBehav.IsKnockedBack();
    }

    public void OnHit(Transform source) {
        knockBehav.Knockback(transform.position - source.position);
    }

    public void SetMoveInputBlocked(bool move) {
        moveInput = !move;
    }

}
