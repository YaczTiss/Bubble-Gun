using UnityEngine;
using System.Collections;

public class bubble_behaviour_script : MonoBehaviour
{
    public playerController facing_left_bool;
    public GameObject bubble;
    private bool isFacingRight = true;
    float timer = 0.2f;
    private float dashingPower = 12;
    public Rigidbody2D rb;
    float value_changer = 1;
    bool isDashing = false; // Flag to prevent overlapping coroutines
    float Elapsedtime;
    private float horizontal;

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
            GameObject.Destroy(bubble);
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


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}

