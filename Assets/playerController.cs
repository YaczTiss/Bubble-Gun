using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    private bool grounded;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        // Flip the player's scale based on input
        if (horizontalInput > 0.01f){
            transform.localScale = new Vector3(4,4,4);
        }
        else if (horizontalInput < (-0.01f)){
            transform.localScale = new Vector3(-4, 4, 4);
        }

        // Jump logic
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void Jump()
    {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            grounded = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}