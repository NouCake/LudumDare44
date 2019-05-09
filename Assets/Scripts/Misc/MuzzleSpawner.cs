using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleSpawner : MonoBehaviour {

    private static MuzzleSpawner spawner;
    private void Awake() {
        spawner = this;
    }

    private List<MuzzleController> muzl;
    public GameObject muzzle;

    private void Start() {
        muzl = new List<MuzzleController>();
    }

    public static void Spawn(Vector2 pos) {
        MuzzleController muz = spawner.GetOrCreate();
        muz.reset();
        muz.transform.position = pos;
    }

    private MuzzleController GetOrCreate() {

        for(int i = 0; i < muzl.Count; i++) {
            if (!muzl[i].gameObject.activeSelf)
                return muzl[i];
        }

        MuzzleController muz = Instantiate(muzzle, transform).GetComponent<MuzzleController>();
        muzl.Add(muz);
        return muz;
    }

}
