using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float normalSpeed;
    public float boostSpeed;
    private float speed;
    private Rigidbody2D rb;
    public GameObject Camera; // reference to the camera

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = normalSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * rb.gravityScale, rb.velocity.y);

        // have the camera track the player's position when he moves past the starting area
        if (transform.position.x > 0)
        {
            Camera.transform.position = new Vector3(this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        }
        // when the player goes back
        else
        {
            Camera.transform.position = new Vector3(0, 0, -10);
        }
    }
 
  void OnCollisionEnter2D(Collision2D collision)
    {
        // give the player a temporary speed boost
        if (collision.gameObject.tag == "Speed")
        {
            StartCoroutine(speeding());
            Destroy(collision.gameObject);
        }
        // send the player back to the start
        else if (collision.gameObject.tag == "Spike")
        {
            transform.position = new Vector2(-3, -3);
        }
       
    }

    // function that temporarily speeds up the player
    IEnumerator speeding()
    {
        speed = boostSpeed;
        yield return new WaitForSeconds(5);
        speed = normalSpeed; 
    }
}
