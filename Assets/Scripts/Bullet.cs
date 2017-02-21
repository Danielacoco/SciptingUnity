using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public int damage;

	Vector3 shootDirection;


	void FixedUpdate() {
		this.transform.Translate (shootDirection * speed, Space.World);
	}

	public void FireProjectile(Ray shootRay){
		this.shootDirection = shootRay.direction;
		this.transform.position = shootRay.origin;
		rotateInShootDirection ();
	}

	void rotateInShootDirection(){
		Vector3 newOrietation = Vector3.RotateTowards (transform.forward, shootDirection, 0.01f, 0.0f);

		transform.rotation = Quaternion.LookRotation (newOrietation);
	}

	void OnCollisionEnter(Collision col){
		Oponent op = col.collider.gameObject.GetComponent<Oponent> ();
		if (op) {
			op.TakeDamage (damage);
		}
		Destroy (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
