using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvaluation : MonoBehaviour
{

    public bool _isColliding = false;
    public bool _isEnabled = false;
    public float CollisionScore = 0;
    AudioManager myAudioMan;
    public Transform firstImpactPoint;
    public GameObject firstImpactCamera;

    private GameObject sliderinfor;

    private void Awake()
    {

        sliderinfor = FindObjectOfType<SliderInfo>().gameObject;
        sliderinfor.SetActive(false);
    }
    private void Start()
    {
        myAudioMan = FindObjectOfType<AudioManager>();
    }

    public void EnableInput()
    {
        sliderinfor.SetActive(true);
    }

    public void StopAnimatorAndWait()
    {
        if (myAudioMan != null)
        {
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.SlowDown);
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Fan, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z));
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Slip_Bathroom_Tile1, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z));

        }
        //Debug.Log("Here");
        this.GetComponent<Animator>().speed = 0;
        foreach (CharacterJoint joint in FindObjectsOfType<CharacterJoint>())
        {
            joint.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        //Debug.Log("FinishAnimation");


        if (FindObjectOfType<SliderInfo>().GetSliderValue > 0.5f)
        {
            FindObjectOfType<UIManager>().Win();
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Fall_Bathroom_Hard1, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z));
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Win, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        }
        else
        {
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Fall_Bathroom_Hard1, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z));
            myAudioMan.TriggerSoundEffect(AudioManager.SoundEffectsEnum.WoodFracture4);

            this.GetComponent<Animator>().enabled = false;
            _isEnabled = true;
            foreach (CharacterJoint joint in FindObjectsOfType<CharacterJoint>())
            {
                joint.GetComponent<Rigidbody>().Sleep();
                joint.GetComponent<Rigidbody>().isKinematic = false;
                joint.GetComponent<Rigidbody>().WakeUp();
            }
            FindObjectOfType<UIManager>().Loss();
        }
        FindObjectOfType<SliderInfo>().enabled = false;
    }

    public void AddCollision(Collision collision, int weight)
    {
        if (!_isEnabled) return;
        if (!_isColliding)
        {
            //Return if the collision is with itself, only consider after they are already touching the ground.
            if (collision.collider.CompareTag("Player")) return;
            firstImpactPoint.position = collision.contacts[0].point;
            firstImpactCamera.SetActive(true);

            _isColliding = true;
            weight *= 2;
        }
        CollisionScore += (collision.relativeVelocity.magnitude) * (float)weight * ((collision.rigidbody != null) ? collision.rigidbody.mass : 1);
    }
}
