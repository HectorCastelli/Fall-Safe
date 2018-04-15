using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public List<AudioClip> BackgroundMusicLibrary = new List<AudioClip>();
    [SerializeField] public List<AudioClip> SoundEffectsLibrary = new List<AudioClip>();
    [Header("Audio Sources")]
    [SerializeField]
    public AudioSource BGMusic1;
    [SerializeField] public AudioSource BGMusic2;
    [SerializeField] public AudioSource PlaySoundEffects;
    public enum SoundEffectsEnum
    {
        x, xx, xxx, xxxx
    }
    public enum BackgroundMusicEnum
    {
        y, yy, yyy, yyyy
    }
    public void FadeBGMusic(BackgroundMusicEnum BGMItem)
    {

        StartCoroutine(FadeMusic(BGMItem));
        BGMusic2.clip = BackgroundMusicLibrary[(int)BGMItem];
        BGMusic2.Play();

    }
    public void StopBGMusic()
    {
        BGMusic1.Stop();
        BGMusic2.Stop();
    }
    public void TriggerSoundEffect(SoundEffectsEnum SEItem)
    {
        PlaySoundEffects.clip = SoundEffectsLibrary[(int)SEItem];
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
