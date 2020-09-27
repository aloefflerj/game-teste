using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigbody;
    /****/
    [Range(100, 10000)][SerializeField] private float jumpForce = 1000f;
    private bool canJump;
    /****/
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private const float GROUND_CHECK_RADIUS = .2f;
    private bool grounded;
    /****/
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        rigbody = GetComponent<Rigidbody2D>();
    }

    

    void FixedUpdate()
    {
        grounded = false;
        grounded = Physics2D.OverlapCircle(groundCheck.position, GROUND_CHECK_RADIUS, whatIsGround);
        if (grounded)
        {
            canJump = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            canJump = false;
            animator.SetBool("isJumping", true);
        }

    }

    public void Jump()
    {
        if (canJump)
        {
            rigbody.AddForce(new Vector2(0f, jumpForce));
        }

        
    }
}
