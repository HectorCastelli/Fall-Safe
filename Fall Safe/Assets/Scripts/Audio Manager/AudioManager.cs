using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] int debugnum;
    [SerializeField] public List<AudioClip> BackgroundMusicLibrary = new List<AudioClip>();
    [SerializeField] public List<AudioClip> SoundEffectsLibrary = new List<AudioClip>();
    [Header("Audio Sources")]
    [SerializeField]
    public AudioSource BGMusic1;
    [SerializeField] public AudioSource BGMusic2;
    [SerializeField] public AudioSource PlaySoundEffects;
    public enum SoundEffectsEnum
    {
        Fan,
        GlassBreak1,
        GlassBreak2,
        GlassBreak3,
        GruntF1,
        GruntF2,
        GruntF3,
        GruntM1,
        GruntM2,
        GruntM3,
        GruntM4,
        GruntM5,
        Lightswitch1,
        Lightswitch2,
        Lightswitch3,
        Lightswitch4,
        Lightswitch5,
        Sting1_Heavy,
        Sting2_Shock,
        Sting3_HardBass,
        Sting4_Cymbals,
        WoodFracture1,
        WoodFracture2,
        WoodFracture3,
        WoodFracture4,
        WoodFracture5,
        WoodFracture6,
        Footstep_Bathroom_Soft1,
        Footstep_Bathroom_Soft2,
        Footstep_Bathroom_Soft3,
        Footstep_Bathroom_Soft4,
        Footstep_Bathroom_Soft5,
        Footstep_Bathroom_Soft6,
        Footstep_Bathroom_Hard1,
        Footstep_Bathroom_Hard2,
        Footstep_Bathroom_Hard3,
        Footstep_Bathroom_Hard4,
        Footstep_Bathroom_Hard5,
        Footstep_Bathroom_Hard6,
        Fall_Bathroom_Soft1,
        Fall_Bathroom_Hard1,
        Slip_Bathroom_Tile1,
        Slip_Bathroom_Tile2,
        HardFall_LivingRoom,
        SoftFall_LivingRoom,
        Footstep_Soft_LivingRoom1,
        Footstep_Soft_LivingRoom2,
        Tripwire_LivingRoom,
        FallSound,
        SlowDown

    }
    public enum BackgroundMusicEnum
    {
        Relaxed,
    }
    private void Update()
    {
        //this is only to test if the things work
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!PlaySoundEffects.isPlaying)
            {
                debugnum++;

                //TriggerSoundEffect(SoundEffectsEnum.Fan, transform.position);
                FadeBGMusic(BackgroundMusicEnum.Relaxed); 
            }

        }
    }
    public void FadeBGMusic(BackgroundMusicEnum BGMItem)
    {

        StartCoroutine(FadeMusic(BGMItem));
      

    }
    public void StopBGMusic()
    {
        BGMusic1.Stop();
        BGMusic2.Stop();
    }
    public void TriggerSoundEffect(SoundEffectsEnum SEItem, Vector3 location = default(Vector3))
    {
        if (!PlaySoundEffects.isPlaying)
        {


            //if not a default location, set the audio source to play a 3d noise. 
            if (location != Vector3.zero)
            {
                PlaySoundEffects.clip = SoundEffectsLibrary[(int)SEItem];
                PlaySoundEffects.spatialBlend = 1;
                AudioSource.PlayClipAtPoint(SoundEffectsLibrary[(int)SEItem], location);
            }
            //is a 2D sound
            else
            {
                PlaySoundEffects.spatialBlend = 0;
                PlaySoundEffects.clip = SoundEffectsLibrary[(int)SEItem];
                PlaySoundEffects.Play();
            }
        }
    }
    IEnumerator FadeMusic(BackgroundMusicEnum BGMitem)
    {
        float musicTimer = 0.0f;
        // this means the first BG audiosource is currently playing.
        //FADE OUT THE FIRST AUDIO SOURCE
        if (BGMusic1.isPlaying)
        {
            BGMusic2.clip = BackgroundMusicLibrary[(int)BGMitem];
            BGMusic2.Play();
            BGMusic2.volume = 0;
            while (!(Mathf.Approximately(musicTimer, 1f)))
            {
                musicTimer = Mathf.Clamp01(musicTimer + Time.deltaTime);
                BGMusic1.volume = 1f - musicTimer;
                BGMusic2.volume = musicTimer;
                yield return new WaitForSeconds(0.02f);
            }
            BGMusic1.Stop();
        }
        //if this happens, it means the original BG audiosource is no longer playing, and the secondary audio source is playing. 
        // FADE OUT THE SECOND AUDIOSOURCE
        else
        {
            BGMusic1.clip = BackgroundMusicLibrary[(int)BGMitem];
            BGMusic1.Play();
            BGMusic1.volume = 0;
            while (!(Mathf.Approximately(musicTimer, 1f)))
            {
                musicTimer = Mathf.Clamp01(musicTimer + Time.deltaTime);
                BGMusic2.volume = 1f - musicTimer;
                BGMusic1.volume = musicTimer;
                yield return new WaitForSeconds(0.02f);
            }
            BGMusic2.Stop();
        }
    }
}
