using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float hInput;

    public FixedJoystick joystick;
    public float moveSpeed;

    void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;

        transform.Translate(hInput, 0, 0);
    }
}
