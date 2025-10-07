using UnityEngine;

public class DarkSamuraiScript : MonoBehaviour
{
    //Declare these variablle at the top of this script
    Rigidbody2D rb;
    public Animator anim;
    SpriteRenderer sr;
    LayerMask groundLayerMask;
    float xvel;
    float yvel;
    public PlayerScript playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        groundLayerMask = LayerMask.GetMask("Ground");
        xvel = 3.5f;
        yvel = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {

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


        rb.linearVelocity = new Vector3(xvel, yvel, 0);


        //check for reaching the edge of a platform
        if (ExtendedRayCollisionCheck(-1, 0) == false)
        {
            if (xvel < 0)
            {
                xvel = -xvel;
            }
        }

        if (ExtendedRayCollisionCheck(1, 0) == false)
        {
            if (xvel > 0)
            {
                xvel = -xvel;
            }
        }

        /*print("Enemy says: The player has " + playerScript.lives + " lives");*/
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            /* print("Enemy has collided with Ground layer"); */
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;
    }
}
