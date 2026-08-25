using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI talkText;
    public GameObject talkTextBg;
    public GameObject npcPlayerIcon;
    public GameObject DanceButton;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateDanceButton()
    {
        DanceButton.SetActive(true);
    }
}
