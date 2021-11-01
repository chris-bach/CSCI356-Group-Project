using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("Gun Settings")]

    //Muzzleflash
    public Image muzzleFlashImage;
    public Sprite[] flashes;

    //Aiming
    public Vector3 normalLocalPosition;
    public Vector3 aimingLocalPosition;

    public float aimSmoothing = 10;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 1;
    private Vector2 _currentRotation;
    public float weaponSwayAmount = 10;

    //Weapon Recoil
    public bool randomizeRecoil;
    public Vector2 randomRecoilConstraints;
    //You only need to assign this if randomize recoil is off
    public Vector2[] recoilPattern;
    public GameHUD _pauseMenu;


    private void Update()
    {
        DetermineAim();
        //DetermineRotation();

        if(Input.GetButtonDown("Fire1") && !_pauseMenu.GamePaused) StartCoroutine(ShootGun());
        
    }
    /*
    private void DetermineRotation()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseAxis *= mouseSensitivity;
        _currentRotation += mouseAxis;

        _currentRotation.y = Mathf.Clamp(_currentRotation.y, -90, 90);

        transform.localPosition += (Vector3)mouseAxis * weaponSwayAmount / 1000;

        transform.root.localRotation = Quaternion.AngleAxis(_currentRotation.x, Vector3.up);
        transform.parent.localRotation = Quaternion.AngleAxis(-_currentRotation.y, Vector3.right);


    }*/
    private void DetermineAim()
    {
        Vector3 target = normalLocalPosition;
        if (Input.GetMouseButton(1)) 
            target = aimingLocalPosition;

        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPosition;
    }


    private void DetermineRecoil()
    {
        transform.localPosition -= Vector3.forward * 0.1f;

        if (randomizeRecoil)
        {
            float xRecoil = Random.Range(-randomRecoilConstraints.x, randomRecoilConstraints.x);
            float yRecoil = Random.Range(-randomRecoilConstraints.y, randomRecoilConstraints.y);

            Vector2 recoil = new Vector2(xRecoil, yRecoil);

            _currentRotation += recoil;
        }
    }

    private IEnumerator ShootGun()
    {
        DetermineRecoil();
        StartCoroutine(MuzzleFlash());
        yield return null;
    }

    private IEnumerator MuzzleFlash()
    {
        muzzleFlashImage.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashImage.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashImage.sprite = null;
        muzzleFlashImage.color = new Color(0, 0, 0, 0);
    }
}