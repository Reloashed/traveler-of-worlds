using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float hInput;
    private bool isParticleOn;

    public FixedJoystick joystick;
    public float moveSpeed = 0.3f;
    public Animator animator;
    public ParticleSystem carParticles;
    public AudioSource audioSource;
    public AudioClip idleAudio;
    public AudioClip driveAudio;
    private bool wasDriving;

    void Start()
    {
        wasDriving = false;
        audioSource.clip = idleAudio;
        audioSource.loop = true;
        audioSource.Play();
    }

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

        bool isDriving = hInput != 0;

        if (isDriving)
        {
            if (!isParticleOn)
            {
                carParticles.Play();
                isParticleOn = true;
            }
            audioSource.clip = driveAudio;
            audioSource.Play();
        }
        else
        {
            if (isParticleOn)
            {
                carParticles.Stop();
                isParticleOn = false;
            }
            audioSource.clip = idleAudio;
            audioSource.Play();
        }

        if (isDriving != wasDriving)
        {
            if (isDriving)
            {
                audioSource.clip = driveAudio;
            }
            else
            {
                audioSource.clip = idleAudio;
            }

            audioSource.loop = true;
            audioSource.Play();

            wasDriving = isDriving;
        }

        animator.SetBool("isDriving", isDriving);
    }
}
