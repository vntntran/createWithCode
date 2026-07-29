using UnityEngine;


public class MoveForward : MonoBehaviour

{
    public float speed = 40.0f;
    private float topBound = 30;
    private float sideBound = -25;
    private float lowerBound = -10;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
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
            Destroy(gameObject);
        }
        // Check if the object has gone beyond the side bounds
        else if (transform.position.x < sideBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > -sideBound)
        {
            Destroy(gameObject);
        }
    }
    // Detect collision with other objects and destroy both objects
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           gameManager.addLives(-1);
           Destroy(gameObject);
           if (gameManager.lives <= 0)
           {
               Debug.Log("Game Over");
               Destroy(other.gameObject);
           }
        }
        else if (other.CompareTag("Dog"))
        {
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
        }
    }
}
