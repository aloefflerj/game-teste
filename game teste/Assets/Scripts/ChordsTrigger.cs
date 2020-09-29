using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordsTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource cChord;
    // Start is called before the first frame update
    void Start()
    {
        cChord = GetComponent<AudioSource>();
        cChord.Stop();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(2f, 0);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
            cChord.Play();
    }
}
