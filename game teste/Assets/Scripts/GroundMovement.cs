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
    private float initialY;
    [SerializeField] float groundVelocity = .5f;
    

    // Start is called before the first frame update
    void Awake()
    {
        cameraSize = camera.orthographicSize;
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        initialY = transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the gorund
        transform.position -= new Vector3(groundVelocity, 0);

        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x) < 0)
        {
            transform.position = new Vector2(30, initialY);
        }
            
        Debug.Log("screenPosition: " + (screenPosition.x - width));
        Debug.Log("Screen.width " + (-Screen.width));
        Debug.Log("width " + (width));
    }
}
