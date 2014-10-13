using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText text;
	public Sprite sprite;
	bool create = true;

	// Use this for initialization
	void Start () {
		//NewGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (create) {
			GridController.GetInstance().SpawnNewTetrimino(sprite);
			//GridController.GetInstance().SetGUIText(text);
			create = false;
		}
	}

/*	void NewGame () {
		grid.Reset();
		spawner.Reset();
	}*/
}
