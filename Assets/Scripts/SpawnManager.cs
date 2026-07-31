using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject car;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject playerSpawn = GameObject.FindWithTag("PlayerSpawn");
        GameObject carSpawn = GameObject.FindWithTag("CarSpawn");

        if (playerSpawn != null && carSpawn != null)
        {
            player.transform.position = playerSpawn.transform.position;
            car.transform.position = carSpawn.transform.position;
        }
    }
}
