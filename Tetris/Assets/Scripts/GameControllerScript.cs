using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public GameObject gridController;
	public GUIText text;
	bool create = true;

	// Use this for initialization
	void Start () {
		//NewGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (create) {
			//gridController.SetSpawnTetrimino(tetrimino);
			//gridController.Activate();
			gridController.GetComponent<GridControllerScript>().SpawnNewTetrimino();
			//GridController.GetInstance().SetGUIText(text);
			create = false;
		}
	}

/*	void NewGame () {
		grid.Reset();
		spawner.Reset();
	}*/
}
