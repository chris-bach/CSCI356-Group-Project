using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	public float walkSpeed = 5.0F;
	private float moveSpeed;
	public float sprintSpeed;
	public Vector3 jumpParameters;
	public bool isGrounded; 
	public float jumpPower = 2F;
	public Rigidbody player;

	private AudioSource gunAudio;
    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        player = GetComponent<Rigidbody>();
        jumpParameters = new Vector3(0F,2F,0F);
        sprintSpeed = walkSpeed * 2;
    }
    void OnCollisionStay(){
    	isGrounded = true;
    }
    void OnCollisionExit(){
    	isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetButtonDown("Fire1")) gunAudio.Play();
    	if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
    		player.AddForce(jumpParameters * jumpPower,ForceMode.Impulse);
    		isGrounded = false;
    	}
    	if(Input.GetKey(KeyCode.LeftShift)) moveSpeed = sprintSpeed;
    	else moveSpeed = walkSpeed;


         
    
        float mvX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    	float mvZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

    	transform.Translate(mvX,0,mvZ);
    }
}
