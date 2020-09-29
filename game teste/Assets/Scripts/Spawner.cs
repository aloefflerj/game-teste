using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform notes;
    public float timeBeforeSpawn = 6f;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("WaitForSpawn", timeBeforeSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeSpawn()
    {
        Debug.Log("started");
        foreach (Transform child in notes)
        {
            Debug.Log(child);
            Transform newChord = Instantiate(child, transform.position, Quaternion.identity);
            
            
            yield return new WaitForSeconds(2f);
        }
    }

    void WaitForSpawn()
    {
        StartCoroutine("TimeSpawn");
    }
}
