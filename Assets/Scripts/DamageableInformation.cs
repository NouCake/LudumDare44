using UnityEngine;
using System.Collections;

public class DamageableInformation {

    public CharController controller;
    public Transform sourceTransform;

    public Stats totalStats;

    public DamageableInformation(CharController controller, Transform source, Stats totalStats) {
        this.controller = controller;
        this.sourceTransform = source;
        this.totalStats = new Stats(totalStats);
    }
    
}
