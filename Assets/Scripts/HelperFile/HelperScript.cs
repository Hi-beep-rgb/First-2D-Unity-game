using Unity.VisualScripting;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public void DoFlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

  /*public void Print(bool write)
    {
        if (write == true)
        {
            print("Hello World");
        }
    }*/
}
