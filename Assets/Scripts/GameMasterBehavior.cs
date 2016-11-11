using UnityEngine;
using System.Collections;


public class GameMasterBehavior : MonoBehaviour {

	public static bool isUp;
	public static bool isDown;
	public static bool isLeft;
	public static bool isRight;

	public const  int NORTH = 0;
	public const int EAST = 1;
	public const int SOUTH = 2;
	public const int WEST = 3;

	public static float speed = 0.5f;

	public static int GLOBAL_TILE_WIDTH = 10;

	//Array of all tiles. ID = index
	public static GameObject[] tilePalete;
	public GameObject[] tilePaleteLoader;
	public TileLayerBehavior[] tileLayers;


	// Use this for initialization
	void Start () {
		isUp = false;
		isDown = false;
		isLeft = false;
		isRight = false;

		tilePalete = new GameObject[tilePaleteLoader.GetLength (0)];
		for (int i = 0; i < tilePaleteLoader.GetLength (0); i++) {
			tilePalete [i] = tilePaleteLoader [i];
		}

	}

	//Call all tile layer move methods
	public void MoveEverything(int dir){
		for (int i = 0; i < tileLayers.GetLength (0); i++) {
			tileLayers [i].Move (dir);
		}
	}
}
