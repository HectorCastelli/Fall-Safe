using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public bool _isEnabled = false;

    [HideInInspector]
    public Vector3 _oldMousePosition;

    public void StopMotion()
    {
        _isEnabled = false;
        //Destroy(this.GetComponent<CharacterJoint>());
        //Destroy(this.GetComponent<Rigidbody>());
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
