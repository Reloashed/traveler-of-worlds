using UnityEngine;

public class HipHopNPC : MonoBehaviour, Activator
{
    public void Activate()
    {
        UIManager.Instance.ActivateDanceButton();
    }
}
