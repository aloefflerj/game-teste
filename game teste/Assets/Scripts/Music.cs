using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour

   
{
    [SerializeField] private AudioSource bgMusic;
    private float musicLenght;
    public string[] _clipNames;
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
        musicLenght = bgMusic.clip.length;
        StartAudio();
    }

    void StartAudio()
    {
        bgMusic.clip = Resources.Load<AudioClip>(_clipNames[i]) as AudioClip;
        Debug.Log(bgMusic.clip);
        bgMusic.Play();

        i++;
        if (i >= _clipNames.Length)
        {
            i = 0;
        }
        Invoke("StartAudio", bgMusic.clip.length);    //0.5f is the delay given after a song is over.

    }
}
