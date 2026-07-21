using UnityEngine;

public interface NpcInteractable
{
    void Interact();
    bool IsInteractable();
    string buttonText();
    public GameObject interactIcon();
    string[] speechBubles();
    GameObject speechBubble();
    void reset();
}
