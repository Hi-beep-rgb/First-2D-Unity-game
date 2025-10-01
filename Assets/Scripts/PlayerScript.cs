using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    bool isGrounded;
    public Animator anim;
    LayerMask groundLayerMask;
    public int lives;
    public bool write;
    public bool flip;

    HelperScript helper;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        lives = 3;

        //Adds the helper script and stores a refrence in it
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {

        //Code for my players movment
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            xvel = -3;
             /*sr.flipX = true;*/
        }

        if (Input.GetKey("d"))
        {
            xvel = 3;
             /*sr.flipX = false;*/
        }

        /*if (Input.GetKey("w") && isGrounded)
        {
            yvel = 5;
        }*/

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

        /*if (xvel >= 0.1f)
        {
            sr.flipX = false;
        }

        if (xvel <= -0.1f)
        {
            sr.flipX = true;
        }*/

        //do ground check

        if (DoRayCollisionCheck() == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //flip sprite
        if( xvel < 0 )
        {
            helper.DoFlipObject(true);
        }
        if (xvel > 0)
        {
            helper.DoFlipObject(false);
        }


    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        print("Player has collided with " +  other.gameObject.name);
    }*/

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
}