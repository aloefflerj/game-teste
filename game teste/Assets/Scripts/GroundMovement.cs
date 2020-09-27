using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float tilesSize;
    private float cameraSize;
    private float thresHold;
    private float width;
    [SerializeField] Camera camera;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraSize = camera.orthographicSize;
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        //foreach (Transform child in transform)
        //{
            width = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
            Debug.Log("widht: " + width);
            
        //}

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Screen.width - transform.GetChild(0).transform.localScale.x);
        transform.position -= new Vector3(0.1f, 0);

        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x) < -100)
        {
            Destroy(gameObject);
        }
            
        Debug.Log("screenPosition: " + (screenPosition.x - width));
        Debug.Log("Screen.width " + (-Screen.width));
        Debug.Log("width " + (width));
    }
}
