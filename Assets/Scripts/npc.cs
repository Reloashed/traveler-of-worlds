using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices;

public class npc : MonoBehaviour, NpcInteractable
{
    private bool isTalking;
    private int iterator = 0;
    private Activator activator = null;

    public string[] voicelines;
    public GameObject speechBubbleIcon;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public bool isActivator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.Instance.talkText.text = "";
        isTalking = false;
        UIManager.Instance.npcPlayerIcon.SetActive(false);
        UIManager.Instance.talkTextBg.SetActive(false);
        speechBubbleIcon.SetActive(false);
        if (isActivator)
        {
            activator = GetComponent<Activator>();
        }
    }

    void Update()
    {
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                startChat(iterator);
            }
        }
    }

    public void Interact()
    {
        if (!isTalking)
        {
            UIManager.Instance.npcPlayerIcon.SetActive(false);
            isTalking = true;
            speechBubbleIcon.SetActive(true);
            UIManager.Instance.talkTextBg.SetActive(true);
            animator.SetBool("isTalking", true);
            startChat(iterator);
        }
    }

    public bool IsInteractable()
    {
        return !isTalking;
    }

    public string[] speechBubles()
    {
        return voicelines;
    }

    private void startChat(int i)
    {
        audioSource.Stop();
        if (iterator < voicelines.Length && isTalking)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            UIManager.Instance.talkText.text = voicelines[i];
            iterator++;
        } else
        {
            if (iterator > 0 && isActivator)
            {
                activator.Activate();
            }
            Reset();
        }
    }

    public GameObject interactIcon()
    {
        return UIManager.Instance.npcPlayerIcon;
    }

    public GameObject speechBubble()
    {
        return speechBubbleIcon;
    }

    public void Reset()
    {
        UIManager.Instance.npcPlayerIcon.SetActive(false);
        speechBubbleIcon.SetActive(false);
        UIManager.Instance.talkText.text = "";
        UIManager.Instance.talkTextBg.SetActive(false);
        isTalking = false;
        animator.SetBool("isTalking", false);
        iterator = 0;
    }
}
