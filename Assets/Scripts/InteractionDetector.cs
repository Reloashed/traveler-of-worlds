using UnityEngine;
using TMPro;

public class InteractionDetector : MonoBehaviour
{

    private Interactable interactableInRange = null;
    private NpcInteractable npcInteractableInRange = null;

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
        if (npcInteractableInRange != null)
        {
            interactionButton.SetActive(false);
            npcInteractableInRange.Interact();
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
        if (collision.TryGetComponent(out NpcInteractable npcInteractable) && npcInteractable.IsInteractable())
        {
            npcInteractableInRange = npcInteractable;
            npcInteractableInRange.interactIcon().SetActive(true);
            interactionButton.SetActive(true);
            interactionText.text = npcInteractable.buttonText();
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
        if (collision.TryGetComponent(out NpcInteractable npcInteractable) && npcInteractable == npcInteractableInRange)
        {
            npcInteractable.reset();
            npcInteractableInRange = null;
            interactionButton.SetActive(false);
        }
    }
}