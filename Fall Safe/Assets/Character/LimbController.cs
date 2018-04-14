using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LimbController : MonoBehaviour {

    public Rigidbody leftElbow, leftArm, rightElbow, rightArm;
    public Rigidbody leftKnee, leftHip, rightKnee, rightHip;

    public float ForceMultiplier = 10f;

    private Player playerArm;
    private Player playerLeg;

    private void Awake()
    {
        playerArm = ReInput.players.GetPlayer(0); //Initialize ReWired.
        playerLeg = ReInput.players.GetPlayer(1); //Initialize ReWired.
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Treat Arms:
        //Extend or Contract?
        leftElbow.AddRelativeTorque(new Vector3(playerArm.GetAxis("LeftArmX"), 0, 0) * ForceMultiplier, ForceMode.Impulse);
        rightElbow.AddRelativeTorque(new Vector3(-playerArm.GetAxis("RightArmX"), 0, 0) * ForceMultiplier, ForceMode.Impulse);

        //Raise or Lower?
        leftArm.AddRelativeTorque(new Vector3(0, 0, playerArm.GetAxis("LeftArmY")) * ForceMultiplier, ForceMode.Impulse);


        //Treat Legs:
        //Extend or Contract?
        leftKnee.AddForce(0, playerArm.GetAxis("LeftLegY") * ForceMultiplier, 0, ForceMode.Impulse);
        rightKnee.AddForce(0, playerArm.GetAxis("RightLegY") * ForceMultiplier, 0, ForceMode.Impulse);
        //Raise or Lower?
        leftHip.AddRelativeTorque(playerArm.GetAxis("LeftLegX") * ForceMultiplier, 0, 0, ForceMode.Impulse);
        rightHip.AddRelativeTorque(playerArm.GetAxis("RightLegX") * ForceMultiplier, 0, 0, ForceMode.Impulse);
    }
}
