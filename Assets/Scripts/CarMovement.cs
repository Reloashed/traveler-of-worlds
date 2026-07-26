using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float hInput;

    public FixedJoystick joystick;
    public float moveSpeed;
    public Animator animator;

    void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;

        transform.Translate(hInput, 0, 0);

        if (hInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (hInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        animator.SetBool("isDriving", hInput != 0);
    }
}
