using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour

{

    [Range(0, 5f)] [SerializeField] private float fallMultiplier = 2.5f;         // Gravity acceleration
    [Range(0, 5f)] [SerializeField] private float lowJumpMultiplier = 2f;       // Force of lowjump
    private Rigidbody2D rigBody;
    // Start is called before the first frame update
    void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigBody.velocity.y < 0)
        {
            rigBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
