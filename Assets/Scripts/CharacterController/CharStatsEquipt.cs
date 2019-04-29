/*
 * using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharStatsEquipt : CharStatsHealth {

    private List<Equipment> equip;
    private CharStats statsEquip;

    public CharStatsEquipt(int maxhealth, int str, int def) : base(maxhealth, str, def) {
        equip = new List<Equipment>(5);
        statsEquip = new CharStats(0, 0);
    }

    public void addEquip(Equipment eq) {
        equip.Add(eq);
    }

    private void UpdateStats() {
        resetStats();
        for(int i = 0; i < equip.Count; i++) {
            physicalStrength += equip[0].stats.GetPhysicalStrength();
            poisonStrength += equip[0].stats.GetPoisonStrength();
            coldStrength += equip[0].stats.GetColdStrength();
            fireStrength += equip[0].stats.GetFiretrength();

            physicalResistance += equip[0].stats.GetPhysicalResistance();
            poisonResistance += equip[0].stats.GetPoisonResistance();
            coldResistance += equip[0].stats.GetColdResistance();
            fireResistance += equip[0].stats.GetFireResistance();
        }
    }
    
    private void resetStats() {
        physicalStrength = 0;
        poisonStrength = 0;
        coldStrength = 0;
        fireStrength = 0;

        physicalResistance = 0;
        poisonResistance = 0;
        coldResistance = 0;
        fireResistance = 0;
    }



}
 
*/