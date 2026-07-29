using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (fireAction.triggered)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            fireAction.Disable();
            Invoke("EnableFireAction", delay);
        }
    }
    void EnableFireAction()
    {
        fireAction.Enable();
    }
}
