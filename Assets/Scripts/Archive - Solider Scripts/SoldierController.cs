using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SoldierController : MonoBehaviour
{
    #region Movement
    public float walkSpeed = 5.0f;
    #endregion

    #region Camera
    public float mouseSensitivity = 2.0f;
    #endregion

    #region GameObjects
    private Camera playerCam;
    private AudioSource gunAudio;
    private RaycastHit hitInfo;
    private UIManager _uIManager;
    #endregion

    #region Combat
    //public int damage = 25;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = GetComponentInChildren<Camera>();
        gunAudio = GetComponent<AudioSource>();
        _uIManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fires weapon in forward camera direction
        if (Input.GetButtonDown("Fire1")){
            gunAudio.Play();
            /*
            Vector3 directionOfFire = playerCam.transform.forward;

            if (Physics.Raycast (playerCam.transform.position, directionOfFire, out hitInfo, 20))
            {
                Debug.DrawLine(playerCam.transform.position, hitInfo.point, Color.yellow);

                drawLine((playerCam.transform.position + hitInfo.point) / 2, hitInfo.point, Color.blue);
                hitInfo.transform.SendMessage("HitByBullet", damage, SendMessageOptions.DontRequireReceiver);
            }*/
        }


        // Mouse move + WASD move
        var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseMove = Vector2.Scale(mouseMove, new Vector2(mouseSensitivity, mouseSensitivity));

        transform.Rotate(0, mouseMove.x, 0);
        playerCam.transform.Rotate(-mouseMove.y, 0, 0);

        float mvX;
        float mvZ;
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            print("Cakked");
            mvX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed * 5;
            mvZ = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed * 5;
        }
        else{
            mvX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
            mvZ = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        }

        transform.Translate(mvX, 0, mvZ);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            //_uIManager.SetActiveGameplay(false);
            //_uIManager.SetActivePauseMenu(true);
        }
    }

    // Gun shoot method
    void drawLine(Vector3 start, Vector3 end, Color color, float duration = 10.0f)
    {
        Debug.Log("Draw line");

        GameObject myline = new GameObject();
        myline.transform.position = start;
        myline.AddComponent<LineRenderer>();
        LineRenderer lr = myline.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Standard"));

        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myline, duration);
    }
}
