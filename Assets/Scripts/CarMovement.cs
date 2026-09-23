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
    public float idleVolume = 0.35f;
    public float driveVolume = 1f;
    private bool wasDriving;

    void Start()
    {
        audioSource.Stop();
        wasDriving = false;
        audioSource.clip = idleAudio;
        audioSource.volume = idleVolume;
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

        bool isDriving = Mathf.Abs(hInput) > 0.001f;

        if (isDriving)
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

        if (isDriving != wasDriving)
        {
            audioSource.clip = isDriving ? driveAudio : idleAudio;
            audioSource.volume = isDriving ? driveVolume : idleVolume;
            audioSource.loop = true;
            audioSource.Play();

            wasDriving = isDriving;
        }

        animator.SetBool("isDriving", isDriving);
    }
}