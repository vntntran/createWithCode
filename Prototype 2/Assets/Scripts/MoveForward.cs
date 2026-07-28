using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private float topBound = 30;
    private float lowerBound = -10;

    void Update()
    {
        //Move the object forward along the z-axis at a constant speed
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // check if the object (Food) has gone beyond the upper bound
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // Check if the object (Animals) has fallen below the lower bound
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
    // Detect collision with other objects and destroy both objects
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
