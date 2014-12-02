using UnityEngine;
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

	/**
	 * Spawn random tetrimino
	 */
	public GameObject Spawn () {
		Debug.Log ("Spawning");
		// clone tetrimino

		TetriminoScript.TYPE randomType = TetriminoScript.TYPE.T; //(TetriminoScript.TYPE) Random.Range(0,7);
		Vector2 spawnPosition = new Vector2(2, 12);
		GameObject cloneTetrimino = (GameObject) Instantiate(spawnTetrimino);
		cloneTetrimino.GetComponent<TetriminoScript>().CreateTetrimino(randomType, spawnPosition, sprites[(int) randomType]);

		return cloneTetrimino;
	}
}
