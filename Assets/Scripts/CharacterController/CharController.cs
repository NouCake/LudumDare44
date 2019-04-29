using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
    
    public CharStats stats;
    public DamageBehaviour dmgBehav;
    private KnockbackBehaviour knockBehav;

    protected Rigidbody2D body;

    private bool moveInput;

    void Start() {
        moveInput = true;
        dmgBehav = new DamageBehaviour(this);
        stats =  new CharStats(100, 5, 5);

        knockBehav = GetComponent<KnockbackBehaviour>();
        body = GetComponent<Rigidbody2D>();

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

    public bool IsMoveInputBlocked() {
        return moveInput;
    }


    public bool IsMoveBlocked() {
        return knockBehav.IsKnockedBack();
    }

    public void Knockback(CharController cha) {
        knockBehav.Knockback(0.5f, transform.position - cha.transform.position);
    }

    public void SetMoveInputBlocked(bool move) {
        moveInput = !move;
    }

}
