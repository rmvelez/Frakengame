using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAndReturn : MonoBehaviour
{
    public float speed;
    public bool callHammer;
    public bool throwHammer;
    public Vector3 player;
    public GameObject mainPlayer;
    public int thrust;
    private Rigidbody2D rb2D;
    public Vector3 currentHammerPos;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        throwHammer = true;
        callHammer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // sets the current position of the object to the position of the player during the game
        currentHammerPos = new Vector2(mainPlayer.transform.position.x, mainPlayer.transform.position.y + 1);

        // when the player clicks on screen
        if (Input.GetMouseButtonDown(0) && throwHammer == true && callHammer == false)
        {
            throwingHammer(); // throw the object
        }

        // when the player clicks again
        else if (Input.GetMouseButtonDown(0) && throwHammer == false && callHammer == true)
        {
            callingHammer(); // bring it back to the player
        }

    }

    // function used to throw the object
    void throwingHammer()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        throwHammer = false;
        callHammer = true;
    }

    void callingHammer()
    {
        transform.position = currentHammerPos;
        throwHammer = true;
        callHammer = false;
    }
}
