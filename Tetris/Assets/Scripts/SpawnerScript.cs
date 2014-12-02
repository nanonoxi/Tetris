﻿using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject spawnTetrimino;

	public Sprite [] sprites; // all available sprites

	// Use this for initialization
	void Start () {
		Random.seed = System.DateTime.Now.Second;
		//Random.seed = 42;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SetSpawnTetrimino (GameObject tetrimino) {
		spawnTetrimino = tetrimino;
	}

	/**
	 * Spawn random tetrimino
	 */
	public GameObject Spawn () {
		Debug.Log ("Spawning");
		// clone tetrimino

		TetriminoScript.TYPE randomType = (TetriminoScript.TYPE) Random.Range(0,7);
		Vector2 spawnPosition = new Vector2(3, 10);
		GameObject cloneTetrimino = (GameObject) Instantiate(spawnTetrimino);
		cloneTetrimino.GetComponent<TetriminoScript>().CreateTetrimino(randomType, spawnPosition, sprites[(int) randomType]);

		return cloneTetrimino;
	}
}
