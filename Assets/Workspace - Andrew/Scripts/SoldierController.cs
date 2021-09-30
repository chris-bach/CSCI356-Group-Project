using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SoldierController : NetworkBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float walkSpeed = 5.0f;
    public GameObject playerCam;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == true)
        {
            GetComponentInChildren<Camera>().enabled = true;
        }
        else
        {
            GetComponentInChildren<Camera>().enabled = false;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer == true)
        {
            playerCam.SetActive(true);
        }
        else
        {
            playerCam.SetActive(false);
            return;
        }

        var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseMove = Vector2.Scale(mouseMove, new Vector2(mouseSensitivity, mouseSensitivity));

        transform.Rotate(0, mouseMove.x, 0);
        playerCam.transform.Rotate(-mouseMove.y, 0, 0);

        float mvX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        float mvZ = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;

        transform.Translate(mvX, 0, mvZ);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
