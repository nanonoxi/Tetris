using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridControllerScript : MonoBehaviour {
	/*
	 * Game states
	 * ===========
	 * Spawn
	 * User
	 * Settle
	 * Clear
	 * Gravity
	 */

	/**
	 * Max X and Y grid coordinates,
	 * using traditional values (ideally. TODO: find trad. Y value)
	 */
	private int X = 10;
	private int Y = 14;

	/**
	 * Additional Y coordinates used for spawning
	 */
	private int Y_spawn = 3;

	private GameObject [,] grid;
	private List<GameObject> allTetriminos;
	private GameObject activeTetrimino;

	public GameObject spawner;

	/**
	 * For debugging
	 */
	private GUIText guiText;

	public void SetGUIText(GUIText text) {
		guiText = text;
	}

	void Start () {
		Reset ();
	}

	void Reset () {
		grid = new GameObject[Y+Y_spawn, X];
		allTetriminos = new List<GameObject>();
		//guiText = new GUIText();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SpawnNewTetrimino () {
		activeTetrimino = spawner.GetComponent<SpawnerScript>().Spawn();
		//this.SetDebugText();
	}

	public void SetDebugText () {
		string text = "";
		for (int y = 0; y < Y; y++) {
			Debug.Log ("Setting text");
			for (int x = 0; x < X; x++) {
				if (grid[y, x] == null) {
					text += "0 ";
				} else {
					text += "1 ";
				}
			}
			text += "\n";
		}
		if (text.Length == 0) {
			text = "Error: values not being set " + X + ":" + Y;
		}

		guiText.text = text;
	}

	/**
	 * Add a single tetrimino block
	 */
	public void AddBlock (int x, int y, GameObject block) {
		if (grid[y, x] == null) {
			grid[y, x] = block;
		}
	}

	public void RemoveBlock (int x, int y) {
		if (grid[y, x] != null) {
			//grid[y, x].SetActive(false);
			grid[y, x] = null;
		}
	}

	public void ClearRow (int y) {
		for (int x = 0; x < X; x++) {
			RemoveBlock(x, y);
		}
	}

	public bool IsRowFull (int y) {
		for (int x = 0; x < X; x++) {
			if (grid[y, x] == null) {
				return false;
			}
		}
		return true;
	}

	/**
	 * Returns number of rows cleared
	 */
	public int ClearRows () {
		int clearedRows = 0;
		for (int y = 0; y < Y; y++) {
			if (IsRowFull(y)) {
				ClearRow(y);
				clearedRows++;
			}
		}
		return clearedRows;
	}

	/**
	 * Move blocks down using non-cascading gravity
	 */
	void HaveSomeGravitas () {
		
	}

	/**
	 * Settle the current active tetrimino in the grid (stop it from moving)
	 */
	void Settle () {
		// update grid
		//activeTetrimino.isMoving = false;
	}
}
