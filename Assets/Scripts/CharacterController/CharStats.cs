using UnityEngine;
using System.Collections;

public class CharStats {

    private int maxhealth;
    private int curhealth;
    private int str;
    private int def;

    public CharStats(int maxhealth, int str, int def) {
        this.maxhealth = maxhealth;
        this.curhealth = maxhealth;

        this.str = str;
        this.def = def;
    }

    public void AddHealth(int amount) {
        SetHealth(curhealth + amount);
    }

    public void SetHealth(int health) {
        curhealth = health;
        curhealth = (int)Mathf.Clamp(curhealth, 0, maxhealth);
        if (curhealth <= 0) {
            OnHealthZero();
        }
    }

    private void OnHealthZero() { 

    }

    public int GetStr() {
        return str;
    }

    public int GetDef() {
        return def;
    }

    public int GetMaxHealth() {
        return maxhealth;
    }

    public int GetCurHealth() {
        return curhealth;
    }

}
