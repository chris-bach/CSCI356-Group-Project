using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
	// Start is called before the first frame update
	public float radius = 5.0f;
	public float power = 500.0f;
	public int health = 3;
	private Rigidbody target;

	void Start()
	{
		target = GetComponent<Rigidbody>();
	}

	void HitByBullet(int damage) // process a message HitByBullet
	{
		health -= damage;
	}

	// Update is called once per frame
	void Update()
	{
		if (health < 1)
			Destroy(gameObject);
	}
}
