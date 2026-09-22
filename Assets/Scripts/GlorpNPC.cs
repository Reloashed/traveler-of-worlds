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
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
