using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Animator animator;
    public FixedJoystick joystick;
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    public GameObject danceButton;

    private Rigidbody2D rb;
    private float hInput;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
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

    public void Dance()
    {
        danceButton.SetActive(false);
        StartCoroutine(CoRoutDance());
    }

    IEnumerator CoRoutDance()
    {
        animator.speed = 0.6f;
        animator.SetBool("isDancing", true);
        yield return new WaitForSeconds(10f);
        animator.SetBool("isDancing", false);
        animator.speed = 1f;
        HipHopNPC.Instance.ShowPortal();
    }
}
