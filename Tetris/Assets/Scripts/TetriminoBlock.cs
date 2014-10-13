using UnityEngine;
using System.Collections;

public class TetriminoBlock : MonoBehaviour {

	public Vector2 coordinates;

	private GameObject blockGO;
	private float textureSize = 0.6f;
	private Vector2 translateVector = new Vector2 (-2f, -3.5f);

	public void Create(Sprite sprite, int coordinateX, int coordinateY) {
		blockGO = new GameObject();
		SpriteRenderer renderer = blockGO.AddComponent<SpriteRenderer>();
		renderer.sprite = sprite;

		coordinates = new Vector2 (coordinateX, coordinateY);

		blockGO.transform.position = translateVector + coordinates*textureSize;
		blockGO.transform.localScale = new Vector3(0.6f, 0.6f, 0);
	}

	/**
	 * Multiply by texture size to get movement of one block width
	 */
	public void Translate(Vector3 translation) {
		blockGO.transform.Translate(translation*textureSize);
	}

	public void SetActive(bool isActive) {
		blockGO.SetActive(isActive);
	}
}
