using System.Timers;
using UnityEngine;
using System.Collections;

public class bubble_behaviour_script : MonoBehaviour
{
    public GameObject bubble;
    float timer = 0.1f;
    private float dashingPower = 12f;
    bool isDashing;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }
    float Elapsedtime;
    // Update is called once per frame
    void Update()
    {
        Elapsedtime += Time.deltaTime;
        if (Elapsedtime < timer)
        {
            StartCoroutine(Launch());
        }
    }
    private IEnumerator Launch()
    {
        isDashing = true;
        float originalGravity = -0.1f;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(timer);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(timer);
    }
}
