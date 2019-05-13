using UnityEngine;
using System.Collections;

public class SentryMovementBehaviour : EnemyMovementBehaviour {

    public float PlayerHeight = 0.2f;
    public float PreferredDistance = 3;
    private Vector2 desiredPos;
    private bool preferedPos;
    private float distanceToPlayer = 100;
    
    protected override bool UpdateMovementInput() {

        Vector2 dist = transform.position - player.transform.position;
        dist -= PlayerHeight * Vector2.up;
        distanceToPlayer = dist.magnitude;
        if (distanceToPlayer < MaxPlayerDistance) {
            Vector2 dir = MyUtility.GetAxisOriented(dist);
            direction = player.transform.position + PreferredDistance * (Vector3)dir - transform.position;
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
        return distanceToPlayer < MaxPlayerDistance;
    }

}
