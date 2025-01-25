/*using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        // Flip the player's scale based on input
        if (horizontalInput > 0.01f){
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < (-0.01f)){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Jump logic
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        body.gravityScale = 7;

        if (Input.GetKey(KeyCode.Space)){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
    }


    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }else
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}*/