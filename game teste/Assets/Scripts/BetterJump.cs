using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigbody;
    /***/
    [Range(0, 5f)] [SerializeField] private float fallMultiplier = 2.5f;
    [Range(0, 5f)] [SerializeField] private float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        rigbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigbody.velocity.y < 0)
        {
            rigbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            Debug.Log("fallmult");
        }
        else if (rigbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("lowjump");
        }
    }
}
