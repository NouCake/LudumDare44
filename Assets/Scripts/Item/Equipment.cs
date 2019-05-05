using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName ="newfile", menuName ="Item/New Equipment")]
public class Equipment : Item{

    public int SlotType;

    public Stats stats;
    public Vector3Int Attack;
    public Vector3Int Defence;

    public Equipment() {
    }

    public void OnEnable(){
        stats = new Stats(0, 0);

        stats.physicalStrength = Attack.x;
        stats.poisonStrength = Attack.y;
        stats.fireStrength = Attack.z;

        stats.physicalResistance = Defence.x;
        stats.poisonResistance = Defence.y;
        stats.fireResistance = Defence.z;
    }

    public void OnHit(CharController me, CharController attacker) {
        attacker.DmgBehav.DealPoisonDamage(2);
    }

    public void OnAttack(CharController me, CharController defender) {
        me.DmgBehav.DealAbsoluteDamage(1);
        defender.DmgBehav.DealAbsoluteDamage(2);
    }


}
