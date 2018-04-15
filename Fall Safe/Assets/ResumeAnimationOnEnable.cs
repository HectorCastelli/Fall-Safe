using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAnimationOnEnable : MonoBehaviour {
    public Animator anim;
    public bool Forwards=true;

    private void OnEnable()
    {
        anim.SetBool("Forward", Forwards);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.speed = 0.2f;


            FindObjectOfType<CollisionEvaluation>().EnableInput();

            AudioManager myAudio = FindObjectOfType<AudioManager>();
            myAudio.TriggerSoundEffect(AudioManager.SoundEffectsEnum.Sting3_HardBass);
            myAudio.FadeBGMusic(AudioManager.BackgroundMusicEnum.Fall);
        }
    }
}
