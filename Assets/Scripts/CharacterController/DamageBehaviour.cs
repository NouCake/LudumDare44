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
        controller.health.AddHealth(-dmg);
    }

    public void DealPhysicalDamage(DamageableInformation other) {
        int OtherStr = other.totalStats.physicalStrength;
        OtherStr = adjustPhysicalDamagePreCalculation(OtherStr);
        int dmg = calculatePhysicalDamage(OtherStr, controller.TotalStats.physicalResistance); //TODO: Get total defence from me
        if (dmg <= 0) dmg = 1;
        controller.health.AddHealth(-dmg);
        controller.OnHit(other.sourceTransform);
    }

    public void DealPoisonDamage(int poison) {
        curpoison += adjustPoisonDamage(poison);
    }

    virtual protected int adjustPhysicalDamagePreCalculation(int str) {
        return str;
    }
    virtual protected int adjustPhysicalDamagePostCalculation(int str){
        return str;
    }

    virtual protected int adjustPoisonDamage(int poisDmg) {
        return poisDmg;
    }

    private int calculatePhysicalDamage(int physicalAttack, int physicalDefense) {

        int dmg = physicalAttack * physicalAttack / physicalDefense;
        if (dmg > 2 * physicalAttack) dmg = 2 * physicalAttack;
        return dmg;
    }

    public bool isPoisoned() {
        return curpoison > 0;
    }

}
