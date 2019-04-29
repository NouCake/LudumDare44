using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquiptmentInventory {

    private List<Equipment> equip;
    public Stats equipStats;

    public EquiptmentInventory() {
        equip = new List<Equipment>(5);
        equipStats = new Stats(0, 0);
    }

    public void addEquip(Equipment eq) {
        equip.Add(eq);
        UpdateStats();
    }

    private void UpdateStats() {
        resetStats();
        for (int i = 0; i < equip.Count; i++) {
            equipStats.physicalStrength += equip[i].stats.physicalStrength;
            equipStats.poisonStrength += equip[i].stats.poisonStrength;
            equipStats.coldStrength += equip[i].stats.coldStrength;
            equipStats.fireStrength += equip[i].stats.fireStrength;

            equipStats.physicalResistance += equip[i].stats.physicalResistance;
            equipStats.poisonResistance += equip[i].stats.poisonResistance;
            equipStats.coldResistance += equip[i].stats.coldResistance;
            equipStats.fireResistance += equip[i].stats.fireResistance;
        }
    }

    private void resetStats() {
        equipStats.physicalStrength = 0;
        equipStats.poisonStrength = 0;
        equipStats.coldStrength = 0;
        equipStats.fireStrength = 0;

        equipStats.physicalResistance = 0;
        equipStats.poisonResistance = 0;
        equipStats.coldResistance = 0;
        equipStats.fireResistance = 0;
    }

}
