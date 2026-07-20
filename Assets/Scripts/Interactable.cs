using UnityEngine;

public interface Interactable
{
    void Interact();
    bool IsInteractable();
    string buttonText();
    public GameObject interactIcon();
}
