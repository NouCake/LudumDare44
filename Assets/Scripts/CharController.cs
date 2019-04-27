using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    private bool moveInput;

    void Start() {
        moveInput = true;

        init();
    }

    protected virtual void init() {
    }

    public bool isMoveInput() {
        return moveInput;
    }

}
