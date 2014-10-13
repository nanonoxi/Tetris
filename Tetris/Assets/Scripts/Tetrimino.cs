using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tetrimino : MonoBehaviour {

	public enum TYPE {I, J, L, O, S, T, Z};
	
	public bool isMoving = false;

	private List<TetriminoBlock> blocks;
	private int[,] coordinates;
	private TYPE type;
	private Sprite sprite;

	private int frames;
	private int speed = 60; // 60 frames per second

	// Use this for initialization
	void Start () {
		frames = 0;
		/*CreateTetrimino (TYPE.I, 0, 0);
		CreateTetrimino (TYPE.J, 1, 1);
		CreateTetrimino (TYPE.L, 3, 1);
		CreateTetrimino (TYPE.O, 6, 5);
		CreateTetrimino (TYPE.S, 1, 5);
		CreateTetrimino (TYPE.T, 3, 10);
		CreateTetrimino (TYPE.Z, 6, 10);*/
	}
	
	// Update is called once per frame
	void Update () {
		if (frames < speed) {
			frames++;
		} else {
			if (blocks == null || blocks.Count < 1) {
				this.enabled = false;
			} else if (isMoving) {
				MoveDown();
				//MoveLeft();
				//MoveRight();
			}
			frames = 0;
		}
	}

	/**
	 * Returns false if down movement not possible
	 */
	bool MoveDown () {
		for (int i = 0; i < 4; i++) {
			coordinates [i, 0] -= 1;
		}

		foreach (TetriminoBlock block in blocks) {
			block.Translate(new Vector3(0, -1, 0));
		}
		return false;
	}

	/**
	 * Returns false if left movement not possible
	 */
	bool MoveLeft () {
		for (int i = 0; i < 4; i++) {
			coordinates [i, 1] -= 1;
		}
		
		foreach (TetriminoBlock block in blocks) {
			block.Translate(new Vector3(-1, 0, 0));
		}
		return false;
	}

	/**
	 * Returns false if right movement not possible
	 */
	bool MoveRight () {
		for (int i = 0; i < 4; i++) {
			coordinates [i, 1] += 1;
		}
		
		foreach (TetriminoBlock block in blocks) {
			block.Translate(new Vector3(1, 0, 0));
		}
		return false;
	}

	/**
	 * Returns false if clockwise movement not possible
	 */
	bool RotateClockwise () {
		return false;
	}

	public void SetSprite (Sprite s) {
		sprite = s;
	}

	public void CreateTetrimino (TYPE t, int x, int y) {
		blocks = new List<TetriminoBlock>(4);
		type = t;
		//sprite = GameObject.Find("Tetrimino_" + type.GetType());

		CreateCoordinates(x, y);
		CreateBlocks();
	}

	void CreateCoordinates(int x, int y) {
		switch (type) {
		case TYPE.I:
			coordinates = new int[,] {
				{y, x-1},
				{y, x},
				{y, x+1},
				{y, x+2}
			};
			break;
		case TYPE.J:
			coordinates = new int[,] {
				{y, x},
				{y, x+1},
				{y+1, x+1},
				{y+2, x+1}
			};
			break;
		case TYPE.L:
			coordinates = new int[,] {
				{y+2, x},
				{y+1, x},
				{y, x},
				{y, x+1}
			};
			break;
		case TYPE.O:
			coordinates = new int[,] {
				{y, x},
				{y+1, x},
				{y, x+1},
				{y+1, x+1}
			};
			break;
		case TYPE.S:
			coordinates = new int[,] {
				{y+2, x},
				{y+1, x},
				{y+1, x+1},
				{y, x+1}
			};
			break;
		case TYPE.T:
			coordinates = new int[,] {
				{y, x},
				{y+1, x},
				{y+2, x},
				{y+1, x+1}
			};
			break;
		case TYPE.Z:
			coordinates = new int[,] {
				{y, x},
				{y+1, x},
				{y+1, x+1},
				{y+2, x+1}
			};
			break;
		default:
			Debug.Log("Error: tetrimino type not found.");
			break;
		}
		

	}

	void CreateBlocks() {
		for (int i = 0; i < 4; i++) {
			TetriminoBlock block = new TetriminoBlock();
			Debug.Log ("sprite is " + sprite);
			block.Create(sprite, coordinates[i,1], coordinates[i,0]);
			blocks.Add(block);
		}
		isMoving = true;
	}

	public List<TetriminoBlock> GetBlocks () {
		return blocks;
	}
}
