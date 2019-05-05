using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquiptmentInventory {

    public delegate void OnEquipChanged();
    public OnEquipChanged OnEquipChangedCallback;
    
    public Stats EquipStats;
    private Equipment[] slots;

    public EquiptmentInventory() {
        slots = new Equipment[3];
        EquipStats = new Stats(0, 0);
    }

    public bool AddEquip(Equipment eq) {
        if (slots[eq.SlotType] != null) return false;
        UIController.get().FillSlot(eq);

        slots[eq.SlotType] = eq;
        UpdateStats();
        OnEquipChangedCallback.Invoke();
        return true;
    }

    private void UpdateStats() {
        resetStats();
        for (int i = 0; i < slots.Length; i++) {
            if (slots[i] == null) continue;
            EquipStats.physicalStrength += slots[i].stats.physicalStrength;
            EquipStats.poisonStrength += slots[i].stats.poisonStrength;
            EquipStats.coldStrength += slots[i].stats.coldStrength;
            EquipStats.fireStrength += slots[i].stats.fireStrength;

            EquipStats.physicalResistance += slots[i].stats.physicalResistance;
            EquipStats.poisonResistance += slots[i].stats.poisonResistance;
            EquipStats.coldResistance += slots[i].stats.coldResistance;
            EquipStats.fireResistance += slots[i].stats.fireResistance;
        }
    }

    private void resetStats() {
        EquipStats.SetAll(0);
    }

}
