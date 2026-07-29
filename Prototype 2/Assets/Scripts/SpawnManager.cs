using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 15;
    public float spawnPosZ = 20;
    public float startDelay = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("SpawnTop", startDelay);
        Invoke("SpawnLeft", startDelay);
        Invoke("SpawnRight", startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTop()
    {
        float spawnInterval = Random.Range(1.0f, 3.0f);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        Invoke("SpawnTop", spawnInterval);
    }

    void SpawnLeft()
    {
        float spawnInterval = Random.Range(1.0f, 3.0f);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-20, 0, Random.Range(2, 15));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        Invoke("SpawnLeft", spawnInterval);
    }

    void SpawnRight()
    {
        float spawnInterval = Random.Range(1.0f, 3.0f);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(20, 0, Random.Range(2, 15));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
        Invoke("SpawnRight", spawnInterval);
    }
}
