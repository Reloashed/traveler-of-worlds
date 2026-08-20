using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Car"))
        {
            Player.Instance.isGrounded = true;
            Player.Instance.animator.SetBool("isJumping", false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Car"))
        {
            Player.Instance.isGrounded = false;
            Player.Instance.animator.SetBool("isJumping", true);
        }
    }
}
