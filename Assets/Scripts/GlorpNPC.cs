using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlorpNPC : MonoBehaviour, Activator
{
    public static GlorpNPC Instance;

    void Start()
    {
        Instance = this;
    }

    public void Activate()
    {
        Debug.Log("GlorpNPC activated! Restarting level...");
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Debug.Log("Restarting level in 2 seconds...");
        yield return new WaitForSeconds(2f);
        Debug.Log("Reloading scene: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
