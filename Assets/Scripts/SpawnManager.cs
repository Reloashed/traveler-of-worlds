using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public GameObject player;
    public GameObject car;
    public FixedJoystick joystick;
    public GameObject carInteractIcon;
    public Button exitCarButton;
    public GameObject jumpButton;
    private GameObject carInstance;

    private int currentLevel = 1;
    private bool loadCar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void NextLevel()
    {
        currentLevel++;

        if (currentLevel >= 2)
        {
            loadCar = true;
        }
        else
        {
            loadCar = false;
        }

        SceneManager.LoadScene("Level" + currentLevel);
    }

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

        if (playerSpawn != null)
        {
            player.transform.position = playerSpawn.transform.position;
        }

        if (loadCar)
        {
            if (carInstance == null)
            {
                carInstance = Instantiate(car);
                DontDestroyOnLoad(carInstance);

                Car carScript = carInstance.GetComponent<Car>();
                carScript.Setup(player, joystick, carInteractIcon, exitCarButton.gameObject, jumpButton);
                exitCarButton.onClick.RemoveAllListeners();
                exitCarButton.onClick.AddListener(carScript.ExitCar);
            }
            GameObject carSpawn = GameObject.FindWithTag("CarSpawn");
            if (carSpawn != null)
            {
                carInstance.transform.position = carSpawn.transform.position;
            }
        }
    }
}
