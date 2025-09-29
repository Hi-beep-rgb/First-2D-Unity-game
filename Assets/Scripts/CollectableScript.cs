using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Collectable has collided with " + other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        
    }
}
