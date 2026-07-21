using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class npc : MonoBehaviour, NpcInteractable
{
    private bool isTalking;
    private int iterator = 0;

    public new string name;
    public string[] voicelines;

    public GameObject playerIcon;
    public GameObject speechBubbleIcon;
    public TextMeshProUGUI talkText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        talkText.text = "";
        isTalking = false;
        playerIcon.SetActive(false);
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
            playerIcon.SetActive(false);
            isTalking = true;
            speechBubbleIcon.SetActive(true);
            startChat(iterator);
        }
    }

    public bool IsInteractable()
    {
        return !isTalking;
    }

    public string buttonText()
    {
        return "Talk to " + name;
    }

    public string[] speechBubles()
    {
        return voicelines;
    }

    private void startChat(int i)
    {
        if (iterator < voicelines.Length && isTalking)
        {
            talkText.text = voicelines[i];
            iterator++;
        } else
        {
            talkText.text = "";
            iterator = 0;
            isTalking = false;
            speechBubbleIcon.SetActive(false);
        }
    }

    public GameObject interactIcon()
    {
        return playerIcon;
    }

    public GameObject speechBubble()
    {
        return speechBubbleIcon;
    }

    public void reset()
    {
        playerIcon.SetActive(false);
        speechBubbleIcon.SetActive(false);
        talkText.text = "";
        isTalking = false;
    }
}
