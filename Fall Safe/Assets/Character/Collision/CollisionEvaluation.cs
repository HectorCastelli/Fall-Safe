using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvaluation : MonoBehaviour {

    public bool _isColliding = false;
    public bool _isEnabled = false;
    public float CollisionScore = 0;

    public Transform firstImpactPoint;
    public GameObject firstImpactCamera;

    public void StopAnimatorAndWait()
    {
        Debug.Log("Here");
        this.GetComponent<Animator>().speed = 0;
    }

    public void EnableRagdoll()
    {
        Debug.Log("FinishAnimation");
        this.GetComponent<Animator>().enabled = false;
        _isEnabled = true;
    }

    public void AddCollision(Collision collision, int weight)
    {
        if (!_isEnabled) return;
        if(!_isColliding)
        {
            //Return if the collision is with itself, only consider after they are already touching the ground.
            if (collision.collider.CompareTag("Player")) return;
            firstImpactPoint.position = collision.contacts[0].point;
            firstImpactCamera.SetActive(true);

            _isColliding = true;
            weight *= 2;
        }
        CollisionScore += (collision.relativeVelocity.magnitude) * (float)weight * ((collision.rigidbody!=null)?collision.rigidbody.mass:1);
    }
}
