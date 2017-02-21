using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public OpFactory oponentFactory;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		var player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		player.onPlayerDeath += onPlayerDeath;
		
	}

	void onPlayerDeath (Player player)
	{
		oponentFactory.SpawnOponents (false);
		Destroy (player.gameObject);

		Invoke ("restartGame", 3);

	}

	void restartGame(){
		var oponents = GameObject.FindGameObjectsWithTag ("Oponent");
		foreach (var oponent in oponents) {
			Destroy (oponent);
		}
		var playerObject = Instantiate (playerPrefab, new Vector3 (0, 0.5f, 0), Quaternion.identity) as GameObject;
		var cameraRig = Camera.main.GetComponent<CameraRig> ();
		cameraRig.target = playerObject;
		oponentFactory.SpawnOponents(true);
		playerObject.GetComponent<Player> ().onPlayerDeath += onPlayerDeath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
