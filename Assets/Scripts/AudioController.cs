using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        LoadSounds();
    }

    public void RestartAudioController()
    {
        LoadSounds();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Play. Nombre incorrecto Audio: " + name);
        }
        else
        {
            s.source.Play();
            //Debug.Log("Largo " + s.clip.length); 
        }

    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Mute. Nombre incorrecto Audio: " + name);
        }
        else
        {
            s.source.volume = 0;
        }

    }

    public void UnMute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("UnMute. Nombre incorrecto Audio: " + name);
        }
        else
        {
            s.source.volume = s.volume;
        }

    }

    public bool audioSourceIsPlaying()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    private void LoadSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    //FindObjectOfType<AudioController>().Play("namesound");
}
