using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
        // Player movement, editable
        public float speed = 20.0f;
        public float turnSpeed = 100.0f;
        // Input system action for movement, bind in the inspector
        public InputAction moveAction;
        // Store the input value for movement
        private Vector2 moveInput;

    // Enable the input action when the script is enabled
    void OnEnable()
        {
            moveAction.Enable();
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        // Move player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        // Lets the player moves left and right, but not turn sideways
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
