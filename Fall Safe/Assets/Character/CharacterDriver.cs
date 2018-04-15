using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDriver : MonoBehaviour {

    List<Rigidbody> rbs = new List<Rigidbody>();

    private void Awake()
    {
        foreach (Rigidbody rb in FindObjectsOfType<Rigidbody>())
            rbs.Add(rb);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetMouseButton(0))
        {
            int index = Random.Range(0, rbs.Count - 1);
            rbs[index].AddForce(new Vector3(0, 1, 0) * Mathf.Sign(Random.Range(-1,1)), ForceMode.Impulse);
            rbs[index].AddTorque(new Vector3(1, 1, 1) * Mathf.Sign(Random.Range(-1, 1)), ForceMode.Impulse);
        }
	}
}
