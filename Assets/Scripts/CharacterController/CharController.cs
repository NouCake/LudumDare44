using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
    
    public DamageBehaviour DmgBehav;
    public KnockbackBehaviour KnockBehav;
    [HideInInspector]
    public HealthController health;

    public Stats BaseStats;
    public Stats TotalStats;

    protected Rigidbody2D body;
    private bool moveInput;

    void Start() {
        health = GetComponent<HealthController>();
        KnockBehav = GetComponent<KnockbackBehaviour>();
        body = GetComponent<Rigidbody2D>();

        moveInput = true;
        DmgBehav = new DamageBehaviour(this);
        BaseStats = new Stats(5, 5);
        BaseStats.maxhealth = health.MaxHealth;
        TotalStats = new Stats(BaseStats);

        init();
    }

    private void Update() {
        DmgBehav.UpdateEffects(Time.deltaTime);
        ControllerUpdate();
    }

    public virtual void OnDeath() {
        gameObject.SetActive(false);
    }

    protected virtual void ControllerUpdate() {

    }

    protected virtual void init() {
    }

    public bool IsMoveInputBlocked() {
        return moveInput;
    }


    public virtual bool IsMoveBlocked() {
        return KnockBehav.IsKnockedBack();
    }

    public virtual void OnHit(Transform source) {
        KnockBehav.Knockback(transform.position - source.position);
    }

    public void SetMoveInputBlocked(bool move) {
        moveInput = !move;
    }

}
