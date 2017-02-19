using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour {

	public float moveSpeed;
	public int health;
	public int damage;
	public Transform targetTransform;

	void FixedUpdate () {
		if(targetTransform != null) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
		}
	}

	public void TakeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			Destroy(this.gameObject);
		}
	}

	public void Attack(Player player) {
		player.health -= this.damage;
		Destroy(this.gameObject);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
