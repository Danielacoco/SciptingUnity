using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public Bullet bulletPrefab;
	public LayerMask mask;

	void shoot (RaycastHit hit) {
		var bullet = Instantiate (bulletPrefab).GetComponent<Bullet> ();
		var pointAboveFloor = hit.point + new Vector3 (0, this.transform.position.y, 0);

		var direction = pointAboveFloor - transform.position;
		var shootRay = new Ray (this.transform.position, direction);
		Debug.DrawRay (shootRay.origin, shootRay.direction * 100.1f, Color.cyan, 2);

		Physics.IgnoreCollision (GetComponent<Collider> (), bullet.GetComponent<Collider> ());

		bullet.FireProjectile (shootRay);
	}

	void raycastOnMouseClick(){
		RaycastHit hit;
		Ray rayToFloor = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

		if (Physics.Raycast(rayToFloor,out hit, 100.0f, mask, QueryTriggerInteraction.Collide)){
			shoot(hit);
			
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool mouseButtonDown = Input.GetMouseButtonDown (0);
		if (mouseButtonDown) {
			raycastOnMouseClick ();
		}
		
	}
}
