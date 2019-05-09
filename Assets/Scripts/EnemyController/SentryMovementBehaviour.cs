using UnityEngine;
using System.Collections;

public class SentryMovementBehaviour : EnemyMovementBehaviour {

    public float PlayerHeight = 0.2f;
    private Vector2 desiredPos;
    private bool preferedPos;
    
    protected override bool UpdateMovementInput() {

        Vector2 dist = transform.position - player.transform.position;
        dist -= PlayerHeight * Vector2.up;
        if (dist.magnitude < MaxPlayerDistance) {
            Vector2 dir = MyUtility.GetAxisOriented(dist);
            direction = player.transform.position + dist.magnitude * (Vector3)dir - transform.position;
            direction += PlayerHeight * Vector2.up;
            if (direction.magnitude > MinPlayerDistance) {
                direction.Normalize();
                preferedPos = false;
                return true;
            }
            preferedPos = true;
        }

        return false;
    }

    public bool HasPreferedPosition() {
        return preferedPos;
    }

}
