using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
	public Rigidbody bullet;
	private Rigidbody bullet_clone;
	public float magnitude = 10F;



    void Update(){
    	if(Input.GetButtonDown("Fire1")){
    		bullet_clone = Instantiate(bullet,transform.position,transform.rotation);
    		bullet_clone.AddForce(transform.forward * magnitude,ForceMode.Impulse);
    	}
    }
}
