using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public InputAction cameraSwitch;
    private bool cameraBool;
    private Vector3 offset = new Vector3(0, 5, -7);
    public GameObject frontCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraSwitch.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cameraBool = cameraSwitch.ReadValue<float>() == 1f;
        if (cameraBool == false)
        {
            frontCamera.SetActive(false);
        }
        else
        {
            frontCamera.SetActive(true);
        }
        transform.position = player.transform.position + offset;
    }
}