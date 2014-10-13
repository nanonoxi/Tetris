using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Random.seed = 42;
	}

	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Spawn random tetrimino
	 */
	public Tetrimino Spawn () {
		Debug.Log ("Spawning");
		Tetrimino.TYPE randomType = (Tetrimino.TYPE) Random.Range(0,7);

		Tetrimino tetrimino = new Tetrimino();
		tetrimino.CreateTetrimino(randomType, 3, 10);

		return tetrimino;
	}
}
