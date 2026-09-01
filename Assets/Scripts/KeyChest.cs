using UnityEngine;
using UnityEngine.InputSystem;

public class KeyChest : MonoBehaviour, Interactable
{
    public GameObject keyInteractIcon;
    public GameObject door;

    private bool playerHasKey = false;

    public void Interact()
    {
        playerHasKey = true;
        door.GetComponent<BoxCollider2D>().isTrigger = true;
        keyInteractIcon.SetActive(false);
    }

    public GameObject interactIcon()
    {
        return keyInteractIcon;
    }

    public bool IsInteractable()
    {
        return !playerHasKey;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyInteractIcon.SetActive(false);
    }
}
