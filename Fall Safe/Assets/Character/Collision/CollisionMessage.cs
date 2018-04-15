using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMessage : MonoBehaviour {

    public int weight = 1;
    private CollisionEvaluation cEval;
    public GameObject HitParticle;

    private void Awake()
    {
        cEval = FindObjectOfType<CollisionEvaluation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (!collision.collider.CompareTag("Player") && FindObjectOfType<CollisionEvaluation>()._isEnabled) Instantiate(HitParticle, collision.contacts[0].point, Quaternion.FromToRotation(this.transform.up,collision.contacts[0].normal));
        cEval.AddCollision(collision, weight);
    }
}
