using UnityEngine;
using System.Collections;

public class DamageableTracker {

    private int max_count = 10;
    private int count = 0;

    private CharController[] tracker;
    public DamageableTracker() {
        tracker = new CharController[max_count];
    }

    public void reset() {
        count = 0;
    }

    public void AddDamageable(CharController cha) {
        
        if(count < max_count) {
            tracker[count++] = cha;
        }

    }

    public bool HasDamageable(CharController cha) {
        if (count >= max_count) return true;

        for(int i = 0; i < count; i++) {
            if (tracker[i] == cha) return true;
        }
        return false;
    }

}
