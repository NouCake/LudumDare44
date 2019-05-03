using UnityEngine;
using System.Collections;

public class Equipment {

    public Stats stats;

    public Equipment() {
        stats = new Stats(20, 20);
    }

    public void OnHit(CharController me, CharController attacker) {
        attacker.dmgBehav.DealPoisonDamage(2);
    }

    public void OnAttack(CharController me, CharController defender) {
        me.dmgBehav.DealAbsoluteDamage(1);
        defender.dmgBehav.DealAbsoluteDamage(2);
    }


}
