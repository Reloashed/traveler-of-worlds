using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public FixedJoystick joystick;
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float hInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;

        transform.Translate(hInput, 0, 0);


        if (hInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (hInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("isRunning", hInput != 0);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }
}
