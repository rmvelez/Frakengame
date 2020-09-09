using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysBounce : MonoBehaviour
{
    // how far you bounce
    public float jumpVelocity;
    public float carryJumpVelocity;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Package")
        {
            rb.velocity = new Vector2(rb.velocity.x, carryJumpVelocity);
        }
        else if (other.gameObject.tag == "Speed")
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }
}
