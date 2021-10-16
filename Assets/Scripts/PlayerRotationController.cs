using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;

    private Camera playerCam;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = GetComponentInChildren<Camera>();

    }

    void Update()
    {
        var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseMove = Vector2.Scale(mouseMove, new Vector2(mouseSensitivity,mouseSensitivity));

        transform.Rotate(0, mouseMove.x, 0);
        playerCam.transform.Rotate(-mouseMove.y,0,0);
    }
}
