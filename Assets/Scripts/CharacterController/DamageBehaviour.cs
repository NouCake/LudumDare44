using System.Collections;
using UnityEngine;

public class DamageBehaviour {
    
    private CharController controller;

    private int curpoison;
    private float poisonTimer;
    private float poisonTickTime = 1f;

    public DamageBehaviour(CharController controller) {
        this.controller = controller;
    }

    public void UpdateEffects(float deltaTime) {
        updatePoison(deltaTime);
    }

    private void updatePoison(float deltaTime) {
        //Debug.Log("PT : " + poisonTimer);
        if(curpoison > 0) {
            
            if(poisonTimer <= 0) {
                DealAbsoluteDamage(curpoison);
                curpoison -= 2;
                if (curpoison < 0) curpoison = 0;

                poisonTimer = poisonTickTime;
            }

            poisonTimer -= deltaTime;
        }
    }

    public void DealAbsoluteDamage(int dmg) {
        if (dmg <= 0) dmg = 1;
        controller.stats.AddHealth(-dmg);
    }

    public void DealPhysicalDamage(CharStats attackingStats) {
        int dmg = calculatePhysicalDamage(controller.stats, attackingStats);
        if (dmg <= 0) dmg = 1;
        controller.stats.AddHealth(-dmg);
    }

    public void DealPoisonDamage(int poison) {
        curpoison += adjustPoisonDamage(poison);
    }

    virtual protected int adjustPhysicalDamage(int str) {
        return str;
    }

    virtual protected int adjustPoisonDamage(int poisDmg) {
        return poisDmg;
    }

    private int calculatePhysicalDamage(CharStats attacking, CharStats defending) {
        int str = adjustPhysicalDamage(attacking.GetStr());
        int dmg = str * str / defending.GetDef();
        if (dmg > 2 * str) dmg = 2 * str;
        return dmg;
    }

    public bool isPoisoned() {
        return curpoison > 0;
    }

}
