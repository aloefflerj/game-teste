using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform notes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeSpawn());
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
}
