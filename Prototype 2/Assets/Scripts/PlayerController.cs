using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    private Vector2 moveInput;
    public float moveSpeed = 15.0f;
    public float maxRangeX = 10.0f;
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
        if (transform.position.x < -maxRangeX)
        {
            transform.position = new Vector3(-maxRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > maxRangeX)
        {
            transform.position = new Vector3(maxRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > 15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
        }
        

        // Player movement
        moveInput = moveAction.ReadValue<Vector2>();
        // transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveInput.y * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * moveInput.x);

        // Fire input
        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position + transform.forward * 2f, transform.rotation);
        }
    }
}
