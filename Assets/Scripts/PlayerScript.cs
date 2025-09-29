using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    bool isGrounded;
    public Animator anim;
    SpriteRenderer sr;
    LayerMask groundLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            xvel = -3;
            /* sr.flipX = true; */
        }

        if (Input.GetKey("d"))
        {
            xvel = 3;
            /* sr.flipX = false; */
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            yvel = 5;
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (xvel >= 0.1f || xvel <= -0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (xvel >= 0.1f)
        {
            sr.flipX = false;
        }

        if (xvel <= -0.1f)
        {
            sr.flipX = true;
        }

        //do ground check

        if (DoRayCollisionCheck() == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Player has collided with " +  other.gameObject.name);
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        //print("isgrounded")
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    */


    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.2f; //Length of the raycast

        //casting the raycast downwards
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            /* print("Player has collided with the Ground layer"); */
            hitColor = Color.green;
        }

        //Drawing the debug ray to show the rays position
        //Turn on gizmos in game editor to see
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hit.collider;
    }


    /*
    float xpos = transform.position.x;
    float ypos = transform.position.y;

    if (Input.GetKeyDown("w"))
    {
        ypos = ypos + 0.1f;
    }

    if (Input.GetKeyDown("a"))
    {
        xpos = xpos - 0.1f;

    }

    if (Input.GetKeyDown("s"))
    {
        ypos = ypos - 0.1f;

    }

    if (Input.GetKeyDown("d"))
    {
        xpos = xpos + 0.1f;
    }

    //limit the x/y position


    transform.position = new Vector3(xpos, ypos, 0);
    */
}