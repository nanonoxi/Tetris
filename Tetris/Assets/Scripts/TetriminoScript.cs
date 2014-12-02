using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TetriminoScript : MonoBehaviour {

	public enum TYPE {I, J, L, O, S, T, Z};

	public bool isMoving = false;

	private List<GameObject> blocks;
	private int[,] layout; // arrangement of tetrimino blocks within a 2x2, 3x3 or 4x4 grid layout
	private Vector2 coordinates; // top left coordinates of tetrimino
	private TYPE type;

	private Sprite sprite;
	private float textureSize = 0.6f;
	private Vector2 translateVector = new Vector2 (-2f, -3.5f);

	private int frames;
	private int speed = 60; // 60 frames per second

	// Use this for initialization
	void Start () {
		frames = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (frames < speed) {
			frames++;
		} else {
			if (blocks == null || blocks.Count < 1) {
				this.enabled = false;
				Debug.Log("Blocks is empty");
			} else if (isMoving) {
				Debug.Log("Moving down");
				MoveDown();
				//MoveLeft();
				//MoveRight();
			}
			frames = 0;
		}
	}

	
	public List<GameObject> GetBlocks () {
		return blocks;
	}
	
	//=== CREATION ==============================================================================

	public void CreateTetrimino (TYPE t, Vector2 c, Sprite s) {
		blocks = new List<GameObject>(4);
		type = t;
		coordinates = c;
		sprite = s;

		CreateLayout();
		CreateBlocks();
	}

	void CreateLayout() {
		switch (type) {
		case TYPE.I: // 4x4 grid size
			layout = new int[,] {
				{0, 0, 0, 0},
				{1, 1, 1, 1},
				{0, 0, 0, 0},
				{0, 0, 0, 0}
			};
			break;
		case TYPE.J: // 3x3
			layout = new int[,] {
				{1, 0, 0},
				{1, 1, 1},
				{0, 0, 0}
			};
			break;
		case TYPE.L: // 3x3
			layout = new int[,] {
				{0, 0, 1},
				{1, 1, 1},
				{0, 0, 0}
			};
			break;
		case TYPE.O: // 2x2
			layout = new int[,] {
				{1, 1},
				{1, 1}
			};
			break;
		case TYPE.S: // 3x3
			layout = new int[,] {
				{0, 1, 1},
				{1, 1, 0},
				{0, 0, 0}
			};
			break;
		case TYPE.T: // 3x3
			layout = new int[,] {
				{0, 1, 0},
				{1, 1, 1},
				{0, 0, 0}
			};
			break;
		case TYPE.Z: // 3x3
			layout = new int[,] {
				{1, 1, 0},
				{0, 1, 1},
				{0, 0, 0}
			};
			break;
		default:
			Debug.Log("Error: tetrimino type not found.");
			break;
		}
	}

	void CreateBlocks() {
		for (int i = layout.GetLength(0)-1; i > -1; i--) {
			for (int j = 0; j < layout.GetLength(1); j++) {
				if (layout[i,j] == 1) {
					GameObject block = new GameObject();
					block.AddComponent<SpriteRenderer>().sprite = sprite;
					
					Vector2 position = new Vector2 (coordinates.x + j, coordinates.y + i);
					block.transform.position = translateVector + position*textureSize;
					block.transform.localScale = new Vector3(0.6f, 0.6f, 0);
					
					blocks.Add(block);
				}
			}
		}

		isMoving = true;
	}

	//=== MOVEMENT ==========================================================================
	
	/**
	 * Returns false if down movement not possible
	 */
	bool MoveDown () {
		coordinates.y -= 1;
		Translate(new Vector3(0, -1, 0), blocks);

		return false;
	}
	
	/**
	 * Returns false if left movement not possible
	 */
	bool MoveLeft () {
		coordinates.x -= 1;
		Translate(new Vector3(-1, 0, 0), blocks);
		
		return false;
	}
	
	/**
	 * Returns false if right movement not possible
	 */
	bool MoveRight () {
		coordinates.x += 1;
		Translate(new Vector3(1, 0, 0), blocks);

		return false;
	}
	
	/**
	 * Returns false if clockwise movement not possible
	 */
	bool RotateClockwise () {
		switch (type) {
		case TYPE.O:
			// doesn't rotate
			break;
		case TYPE.I:
			// 4x4 grid of blocks
			break;
		case TYPE.J:
		case TYPE.L:
		case TYPE.S:
		case TYPE.T:
		case TYPE.Z:
			// 3x3 grid of blocks

			break;
		default:
			Debug.Log("Error: tetrimino type not found.");
			break;
		}
		return false;
	}
	
	/**
	 * Multiply by texture size to get movement of one block width
	 */
	void Translate(Vector3 translation, List<GameObject> blocks) {
		foreach (GameObject block in blocks) {
			block.transform.Translate(translation*textureSize);
		}
	}
}
