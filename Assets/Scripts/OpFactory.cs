using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpFactory : MonoBehaviour {

	public bool shouldSpawn;
	public Oponent[] oponentPrefabs;
	public float[] moveSpeedRange;
	public int[] healthRange;

	private Bounds spawnArea;
	private GameObject player;

	public void SpawnOponents (bool shouldSpawn){
		if (shouldSpawn) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
		this.shouldSpawn = shouldSpawn;
	}
	Vector3 randomSpawnPosition(){
		float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
		float z = Random.Range (spawnArea.min.z, spawnArea.max.z);
		float y = 0.5f;

		return new Vector3 (x, y, z);
	}

	void spawnOponent(){
		if (shouldSpawn == false || player == null) {
			return;
		}
		int index = Random.Range (0, oponentPrefabs.Length);
		var newOp = Instantiate (oponentPrefabs [index], randomSpawnPosition (), Quaternion.identity) as Oponent;
		newOp.Initialize(player.transform, Random.Range(moveSpeedRange[0], moveSpeedRange[1]),
			Random.Range(healthRange[0], healthRange[1]));
	}


	// Use this for initialization
	void Start () {
		spawnArea = this.GetComponent<BoxCollider>().bounds;
		SpawnOponents(shouldSpawn);
		InvokeRepeating ("spawnOponent", 0.5f, 1.0f);
		
	}

}
