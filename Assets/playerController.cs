using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class playerController : MonoBehaviour
{
    public GameObject bubble;
    public Rigidbody2D body;
    public float speed = 5f;
    public float jump = 3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    private bool grounded;
    public Transform shootingpoint;
    private bool isFacingRight = true;
    private float horizontal;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        // Flip the player's scale based on input
        

        // Jump logic
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        if (Input.GetMouseButtonDown(0))
        {
            spawnBubble();
        }
        Flip();
    }

    void spawnBubble()
    {
        Instantiate(bubble,shootingpoint.position, transform.rotation);
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


    private void Jump()
    {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
            grounded = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}