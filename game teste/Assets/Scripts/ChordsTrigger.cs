using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordsTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource chord;
    [SerializeField] private AudioClip c;
    private Music music;
    // Start is called before the first frame update
    void Awake()
    {
        //cChord = GetComponent<AudioSource>();
        StartCoroutine("MovementsBySecond");
        music = GameObject.Find("MusicManager").GetComponent<Music>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            //chord.PlayOneShot(c);
            float diff = Mathf.Abs(music.bgMusic.time - Mathf.Round(music.bgMusic.time));
            Invoke("PlayOnTime", diff);
        }
            

        Debug.Log("Música tempo: " + (music.bgMusic.time));
        Debug.Log("Rounded music: " + Mathf.Round(music.bgMusic.time));
        Debug.Log("Diff: " + (music.bgMusic.time - Mathf.Round(music.bgMusic.time)));
        
    }

    void PlayOnTime()
    {
        chord.PlayOneShot(c);
        Debug.Log("Corrected Music Time: " + (music.bgMusic.time));
    }

    IEnumerator MovementsBySecond()
    {
        while (true)
        {
            transform.position -= new Vector3(0.5f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        

    }
}
