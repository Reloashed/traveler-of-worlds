using UnityEngine;

public class Portal : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnManager.Instance.NextLevel();
        }
    }
}
