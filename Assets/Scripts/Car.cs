using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour, Interactable
{

    private bool isOccupied = false;

    private GameObject exitButton;
    private GameObject jumpButton;
    private GameObject player;
    private GameObject playerIcon;
    public Animator animator;
    private CarMovement carMovement;

    public void Setup(
        GameObject player,
        FixedJoystick joystick,
        GameObject playerIcon,
        GameObject exitButton,
        GameObject jumpButton)
    {
        this.player = player;
        this.playerIcon = playerIcon;
        this.exitButton = exitButton;
        this.jumpButton = jumpButton;

        carMovement = GetComponent<CarMovement>();
        carMovement.joystick = joystick;
        carMovement.enabled = false;
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

    private void EnterCar()
    {
        isOccupied = true;
        jumpButton.SetActive(false);
        exitButton.SetActive(true);
        player.layer = LayerMask.NameToLayer("PlayerInCar");
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.transform.SetParent(transform);
        player.transform.localPosition = Vector2.zero;
        GetComponent<CarMovement>().enabled = true;
        animator.SetBool("isEmpty", false);
    }

    public void ExitCar()
    {
        isOccupied = false;
        exitButton.SetActive(false);
        jumpButton.SetActive(true);
        player.transform.localPosition = Vector2.right * 2f;
        player.transform.SetParent(null);
        player.layer = LayerMask.NameToLayer("Player");
        player.GetComponent<PolygonCollider2D>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<CarMovement>().enabled = false;
        animator.SetBool("isEmpty", true);
    }

    public GameObject interactIcon()
    {
        return playerIcon;
    }
}
