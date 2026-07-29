using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Game Over!");
        }
    }
}
