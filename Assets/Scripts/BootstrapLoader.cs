using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLoader : MonoBehaviour
{
    
    [SerializeField] private string firstLevel = "Level1";

    void Start()
    {
        SceneManager.LoadScene(firstLevel);
    }
}
