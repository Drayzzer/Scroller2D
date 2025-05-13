using System;
using System.Collections;
using JetBrains.Annotations;
using Menu;
using UnityEngine;
using UnityEngine.Rendering;

//permet d'avoir obligatoirement une audio source 
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    //permet de mettre toute les musics dedans si j'en veux plusieurs
    [SerializeField] private AudioClip[] clip;
    // va permettre de changer de music quand celle actuelle est terminée
    [SerializeField] private bool autoPlay;
    
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    private void Update()
    {
        source.volume = MenuController.Volume;
    }

    public void PlayRandomMusic()
    {
        if (!CanPlay) return;

        AudioClip clip = GetRandommusic();
        StartCoroutine(PlayMusic(clip, autoPlay));
    }

    private IEnumerator PlayMusic(AudioClip clip, bool playOnEnd)
    {
        source.PlayOneShot(clip);
        
        yield return new WaitForSeconds(clip.length);

        if (playOnEnd)
        {
            PlayRandomMusic();
        }
    }

    private AudioClip GetRandommusic()
    {
        return clip[UnityEngine.Random.Range(0, clip.Length)];
    }

    private bool CanPlay
    {
        get
        {
            bool result = clip != null && clip.Length > 0;
            
            if (!result)
                Debug.LogError("there are no music clips");
            
            return result;
        }
    }
}
