using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    private Vector2 moveInput;
    public float moveSpeed = 15.0f;
    public float maxRange = 10.0f;
    public InputAction fireAction;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Keep player in bounds
        if (transform.position.x < -maxRange)
        {
            transform.position = new Vector3(-maxRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > maxRange)
        {
            transform.position = new Vector3(maxRange, transform.position.y, transform.position.z);
        }

        // Player movement
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);

        // Fire input
        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
