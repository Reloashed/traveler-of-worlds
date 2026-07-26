using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour, Interactable
{

    private bool isOccupied = false;

    public GameObject exitButton;
    public GameObject player;
    public GameObject[] toDeactivate;
    public GameObject playerIcon;
    public Animator animator;

    void Start()
    {
        exitButton.SetActive(false);
        GetComponent<CarMovement>().enabled = false;
        playerIcon.SetActive(false);
    }

    public void Interact()
    {
        if (!isOccupied)
        {
            EnterCar();
        }
    }

    public bool IsInteractable()
    {
        return !isOccupied;
    }

    public string buttonText()
    {
        return "Enter Car";
    }

    private void EnterCar()
    {
        isOccupied = true;
        exitButton.SetActive(true);
        for (int i = 0; i < toDeactivate.Length; i++)
        {
            toDeactivate[i].SetActive(false);
        }
        player.layer = LayerMask.NameToLayer("PlayerInCar");
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.transform.SetParent(transform);
        player.transform.localPosition = Vector2.zero;
        GetComponent<CarMovement>().enabled = true;
        animator.SetBool("isEmpty", false);
    }

    public void ExitCar()
    {
        isOccupied = false;
        exitButton.SetActive(false);
        for (int i = 0; i < toDeactivate.Length; i++)
        {
            toDeactivate[i].SetActive(true);
        }
        player.transform.SetParent(null);
        player.transform.localPosition = Vector2.right * 1f;
        player.layer = LayerMask.NameToLayer("Player");
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CarMovement>().enabled = false;
        animator.SetBool("isEmpty", true);
    }

    public GameObject interactIcon()
    {
        return playerIcon;
    }
}
