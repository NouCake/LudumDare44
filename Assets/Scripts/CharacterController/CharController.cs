using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
    
    public CharStats stats;
    public DamageBehaviour dmgBehav;

    private bool moveInput;

    void Start() {
        moveInput = true;
        dmgBehav = new DamageBehaviour(this);
        stats =  new CharStats(100, 5, 5);
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

    public bool isMoveInput() {
        return moveInput;
    }

}
