using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquiptmentInventory {

    private List<Equipment> equip;
    public Stats EquipStats;

    public EquiptmentInventory() {
        equip = new List<Equipment>(5);
        EquipStats = new Stats(0, 0);
    }

    public void addEquip(Equipment eq) {
        equip.Add(eq);
        UpdateStats();
    }

    private void UpdateStats() {
        resetStats();
        for (int i = 0; i < equip.Count; i++) {
            EquipStats.physicalStrength += equip[i].stats.physicalStrength;
            EquipStats.poisonStrength += equip[i].stats.poisonStrength;
            EquipStats.coldStrength += equip[i].stats.coldStrength;
            EquipStats.fireStrength += equip[i].stats.fireStrength;

            EquipStats.physicalResistance += equip[i].stats.physicalResistance;
            EquipStats.poisonResistance += equip[i].stats.poisonResistance;
            EquipStats.coldResistance += equip[i].stats.coldResistance;
            EquipStats.fireResistance += equip[i].stats.fireResistance;
        }
    }

    private void resetStats() {
        EquipStats.SetAll(0);
    }

}
