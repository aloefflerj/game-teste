using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

    
{

    [SerializeField]
    private CharacterController controller;
    [HideInInspector]
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }

    void FixedUpdate()
    {
        if (jump)
        {
            controller.Jump();
            jump = false;
        }   
    }
}
