using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
    
    public DamageBehaviour dmgBehav;
    private KnockbackBehaviour knockBehav;
    public HealthController health; //Hide in Inspector

    public Stats stats;

    protected Rigidbody2D body;

    private bool moveInput;

    void Start() {
        health = GetComponent<HealthController>();
        knockBehav = GetComponent<KnockbackBehaviour>();
        body = GetComponent<Rigidbody2D>();

        moveInput = true;
        dmgBehav = new DamageBehaviour(this);
        stats = new Stats(5, 5);
        stats.maxhealth = health.MaxHealth;

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

    public Stats GetTotalStats() {
        return stats;
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
