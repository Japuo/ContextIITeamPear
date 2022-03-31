using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public float fadeTime;
    public float musicBaseVolume = 1.0f;
    public AudioSource[] audioSources;
    int currentSource;
    public AudioClip firstTrack;
    public bool playOnAwake = true;
    bool switching;

    // Start is called before the first frame update
    void Start()
    {
        currentSource = 0; 
        if(playOnAwake)
        {
            audioSources[currentSource].clip = firstTrack;
            audioSources[currentSource].Play();
        }
        switching = false;
        foreach (AudioSource aS in audioSources) { aS.volume = musicBaseVolume; }
    }

    public void SwitchToTrack(AudioClip clip)
    {
        StartCoroutine(SwitchTrack(clip));
    }

    IEnumerator SwitchTrack(AudioClip newTrack)
    {
        if (switching || newTrack == audioSources[currentSource].clip) { yield break; }
        
        switching = true;

        AudioSource oldSource = audioSources[currentSource];
        currentSource++; currentSource %= 2;
        AudioSource newSource = audioSources[currentSource];
        newSource.clip = newTrack;
        
        newSource.Play();
        float t = 0;
        while(t <= 1.0f)
        {
            oldSource.volume = (1.0f - t) * musicBaseVolume;
            newSource.volume = t * musicBaseVolume;
            t += Time.unscaledDeltaTime / fadeTime;
            yield return null;
        }

        oldSource.volume = 0.0f;
        newSource.volume = musicBaseVolume;

        oldSource.Stop();
        switching = false;
    }
}
