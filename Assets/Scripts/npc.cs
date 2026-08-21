using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class npc : MonoBehaviour, NpcInteractable
{
    private bool isTalking;
    private int iterator = 0;

    public string[] voicelines;
    public GameObject speechBubbleIcon;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.Instance.talkText.text = "";
        isTalking = false;
        UIManager.Instance.npcPlayerIcon.SetActive(false);
        UIManager.Instance.talkTextBg.SetActive(false);
        speechBubbleIcon.SetActive(false);
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
        if (iterator < voicelines.Length && isTalking)
        {
            UIManager.Instance.talkText.text = voicelines[i];
            iterator++;
        } else
        {
            reset();
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

    public void reset()
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
