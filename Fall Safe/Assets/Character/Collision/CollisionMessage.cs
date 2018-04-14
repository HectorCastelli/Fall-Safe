using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMessage : MonoBehaviour {

    public int weight = 1;
    private CollisionEvaluation cEval;

    private void Awake()
    {
        cEval = FindObjectOfType<CollisionEvaluation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        cEval.AddCollision(collision, weight);
    }
}
