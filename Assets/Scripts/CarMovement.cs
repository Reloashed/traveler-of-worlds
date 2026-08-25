using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float hInput;
    private bool isParticleOn;

    public FixedJoystick joystick;
    private float moveSpeed = 1f;
    public Animator animator;
    public ParticleSystem carParticles;

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
        if (hInput != 0)
        {
            if (!isParticleOn)
            {
                carParticles.Play();
                isParticleOn = true;
            }
        }
        else
        {
            if (isParticleOn)
            {
                carParticles.Stop();
                isParticleOn = false;
            }
        }
        animator.SetBool("isDriving", hInput != 0);
    }
}
