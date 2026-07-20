using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class npc : MonoBehaviour, Interactable, NpcInteractable
{
    private bool isTalking;
    private int iterator = 0;

    public new string name;
    public string[] voicelines;

    public GameObject talkButton;
    public GameObject playerIcon;
    public TextMeshProUGUI talkText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        talkButton.SetActive(false);
        talkText.text = "";
        isTalking = false;
        playerIcon.SetActive(false);
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
            isTalking = true;
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
        }
    }

    public GameObject interactIcon()
    {
        return playerIcon;
    }
}
