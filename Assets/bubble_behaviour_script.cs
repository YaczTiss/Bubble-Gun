using UnityEngine;
using System.Collections;

public class bubble_behaviour_script : MonoBehaviour
{
    public playerController facing_left_bool;
    public GameObject bubble;
    float timer = 0.2f;
    private float dashingPower = 12;
    public Rigidbody2D rb;
    bool isDashing = false; // Flag to prevent overlapping coroutines
    float Elapsedtime;
    private float horizontal;
    private bool hasBoxInside = false;
    private GameObject boxInside;

    void Start()
    {
        // Get the reference to the playerController
        facing_left_bool = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        
    }

    void Update()
    {
        Elapsedtime += Time.deltaTime;

        

        // Start the launch coroutine only once during the time interval
        if (Elapsedtime < timer && !isDashing)
        {
            StartCoroutine(Launch());
        }

        // Destroy the bubble after 8 seconds
        if (Elapsedtime > 8f)
        {
            PopBubble();
        }
    }

    private IEnumerator Launch()
    {

        horizontal = Input.GetAxis("Horizontal");
        isDashing = true;

        // Save the original gravity scale
        float originalGravity = rb.gravityScale;
  

        // Temporarily disable gravity
        rb.gravityScale = 0f;

        // Set velocity for dashing
        rb.linearVelocity = new Vector2(horizontal * dashingPower, 0f);

        // Wait for the dash timer
        yield return new WaitForSeconds(timer);

        // Restore gravity scale
        rb.gravityScale = originalGravity;
        Debug.Log($"Restored Gravity: {rb.gravityScale}");

        isDashing = false; // Reset the flag


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && !hasBoxInside)
        {
            // Attach the box to the bubble
            hasBoxInside = true;
            boxInside = collision.gameObject;

            // Set the box as a child of the bubble for movement
            boxInside.transform.SetParent(transform);

            // Optionally disable box's Rigidbody for smoother movement
            Rigidbody2D boxRb = boxInside.GetComponent<Rigidbody2D>();
            if (boxRb != null)
            {
                boxRb.isKinematic = true;
                boxRb.linearVelocity = Vector2.zero;
            }
        }
    }

    private void PopBubble()
    {
        if (hasBoxInside)
        {
            // Detach the box from the bubble
            boxInside.transform.SetParent(null);

            // Re-enable the Rigidbody of the box
            Rigidbody2D boxRb = boxInside.GetComponent<Rigidbody2D>();
            if (boxRb != null)
            {
                boxRb.isKinematic = false;
            }

            // Optionally, add some physics effect to the box (e.g., gravity or slight push)
        }

        // Destroy the bubble
        Destroy(gameObject);
    }
}



