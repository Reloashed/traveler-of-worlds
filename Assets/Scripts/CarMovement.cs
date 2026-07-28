using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float hInput;
    private bool isParticleOn;

    public FixedJoystick joystick;
    public float moveSpeed;
    public Animator animator;
    public ParticleSystem particleSystem;

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
                particleSystem.Play();
                isParticleOn = true;
            }
        } 
        else
        {
            if (isParticleOn)
            {
                particleSystem.Stop();
                isParticleOn = false;
            }
        }
        animator.SetBool("isDriving", hInput != 0);
    }
}
