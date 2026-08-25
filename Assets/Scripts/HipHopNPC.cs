using System.Collections;
using UnityEngine;

public class HipHopNPC : MonoBehaviour, Activator
{
    public static HipHopNPC Instance;

    public GameObject portal;
    public GameObject speechBubbleIcon;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        Instance = this;
        portal.SetActive(false);
    }

    public void Activate()
    {
        UIManager.Instance.ActivateDanceButton();
    }

    public void ShowPortal()
    {
        StartCoroutine(Talking());
        portal.SetActive(true);
    }

    IEnumerator Talking()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        UIManager.Instance.talkText.text = "WOW! That looked very professional! I am impressed!";
        UIManager.Instance.talkTextBg.SetActive(true);
        speechBubbleIcon.SetActive(true);
        animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(5f);
        UIManager.Instance.talkText.text = "";
        UIManager.Instance.talkTextBg.SetActive(false);
        speechBubbleIcon.SetActive(false);
        animator.SetBool("isTalking", false);
    }
}
