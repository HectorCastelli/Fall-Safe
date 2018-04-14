using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvaluation : MonoBehaviour {

    public bool _isColliding = false;
    public float CollisionScore = 0;

    public Transform firstImpactPoint;

    public void AddCollision(Collision collision, int weight)
    {
        if(!_isColliding)
        {
            //Return if the collision is with itself, only consider after they are already touching the ground.
            if (collision.collider.CompareTag("Player")) return;
            firstImpactPoint.position = collision.contacts[0].point;
            _isColliding = true;
            weight *= 2;
        }
        CollisionScore += (collision.relativeVelocity.magnitude) * (float)weight * ((collision.rigidbody!=null)?collision.rigidbody.mass:1);
    }
}
