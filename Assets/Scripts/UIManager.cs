using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI talkText;
    public GameObject npcPlayerIcon;

    private void Awake()
    {
        Instance = this;
    }
}
