﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElbow : MonoBehaviour
{

    public bool _isEnabled = false;

    private Vector3 _oldMousePosition;

    // Update is called once per frame
    void Update()
    {
        if (!_isEnabled) return;
        if (Input.GetMouseButton(0))
        {
            //Get Mouse Delta
            Vector3 mouseDelta = Input.mousePosition - _oldMousePosition;
            _oldMousePosition = Input.mousePosition;
            //Manipulate Right Arm
            //X is shoulder
            //Y is elbow
            this.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, mouseDelta.y, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isEnabled = false;
            //Destroy(this.GetComponent<CharacterJoint>());
            //Destroy(this.GetComponent<Rigidbody>());
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}