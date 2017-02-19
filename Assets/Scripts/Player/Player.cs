using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 3;

	void collideWithOponent (Oponent oponent){
		oponent.Attack (this);
		if (health <= 0) {
			//do something
		}
		
		
	}
	void OnCollisionEnter(Collision colision){
		Oponent op = colision.collider.gameObject.GetComponent<Oponent> (); 
		if (op) {
			collideWithOponent (op);
		}
	}
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
