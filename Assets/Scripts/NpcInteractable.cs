using UnityEngine;

public interface NpcInteractable
{
    void Interact();
    bool IsInteractable();
    public GameObject interactIcon();
    string[] speechBubles();
    GameObject speechBubble();
    void Reset();
}
