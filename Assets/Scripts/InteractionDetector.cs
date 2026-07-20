using UnityEngine;
using TMPro;

public class InteractionDetector : MonoBehaviour
{

    private Interactable interactableInRange = null;

    public GameObject interactionButton;
    public TextMeshProUGUI interactionText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionButton.SetActive(false);
    }

    public void OnInteract()
    {
        if (interactableInRange != null)
        {
            interactableInRange.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable.IsInteractable())
        {
            interactableInRange = interactable;
            interactableInRange.interactIcon().SetActive(true);
            interactionButton.SetActive(true);
            interactionText.text = interactable.buttonText();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable == interactableInRange)
        {
            interactableInRange.interactIcon().SetActive(false);
            interactableInRange = null;
            interactionButton.SetActive(false);
        }
    }
}