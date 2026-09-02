using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FerdinandNPC : MonoBehaviour, Activator
{
    public GameObject portal;

    public void Activate()
    {
        portal.SetActive(true);
    }

    void Start()
    {
        portal.SetActive(false);
    }
}
