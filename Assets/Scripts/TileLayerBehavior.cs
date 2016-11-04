using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * The TileLayer Class
 * 		Creates a field of tiles. 
 * 
 * 
 */
public class TileLayerBehavior : MonoBehaviour {

	//Multidimensional array for initial tiles
	private short[,] idMap;

	//The width of a tile
	public int tileWidth = 10;

	public int layerNum = 0;

	private List<GameObject> tiles;

	// Use this for initialization
	void Start () {

		tiles = new List<GameObject> ();

		if (layerNum == 0) {
			idMap = new short[,] {
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1 },
				{ 1, 2, 2, 2, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 2, 1, 2, 1, 1, 1 },
				{ 1, 1, 2, 1, 1, 2, 2, 1, 1, 2, 1, 2, 1, 2, 1, 1, 2, 2, 1, 1 },
				{ 1, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 2, 2, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 2, 2, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
			};
		} else if (layerNum == 1) {
			idMap = new short[,] {
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  3,  3,  3 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  3, -1, -1 },
				{   3,  3,  3,  3,  3,  3,  3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1,  3, -1, -1, -1,  3,  3,  3, -1, -1, -1, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1,  3, -1, -1, -1,  3, -1,  3, -1, -1, -1, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1,  3, -1, -1, -1,  3, -1,  3,  3,  3,  3, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1,  3,  3,  3,  3,  3, -1, -1, -1, -1,  3, -1,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  3,  3,  3, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
				{  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
			} ;
		}
			
		RebuildTileMap ();
	}

	void Update(){
		/*
		//Debug test code to test movement
		if (Time.frameCount % 25 == 0) {
			
			int r = Random.Range (0, 4);
			int m = 20;

			if (layerNum == 0) {
				List<GameObject> temp = new List<GameObject> ();
				for (int i = 0; i < m; i++) {
					temp.Add ((GameObject)Instantiate (GameMasterBehavior.tilePalete [Random.Range (1, 3)], Vector3.zero, Quaternion.identity));
				}
				MoveEdgeTiles (r, temp);
			} else if (layerNum == 1) {
				/*List<GameObject> temp = new List<GameObject> ();
				for (int i = 0; i < m; i++) {
					temp.Add ((GameObject)Instantiate (GameMasterBehavior.tilePalete [3], Vector3.zero, Quaternion.identity));
				}
				MoveEdgeTiles (r, temp);
			}
			

		}*/


	}

	/*
	 * Builds the tile layer from idMap array. Should only call once.
	 */ 
	void RebuildTileMap(){
		for (int x = 0; x < idMap.GetLength(0); x++) {
			for (int z = 0; z < idMap.GetLength (1); z++) {
				if (idMap [x, z] >= 0) {
					GameObject tile = (GameObject)Instantiate (GameMasterBehavior.tilePalete [idMap [x, z]], new Vector3 (x * tileWidth - idMap.GetLength (0) / 2 * tileWidth, layerNum, z * tileWidth - idMap.GetLength (1) / 2 * tileWidth), Quaternion.identity);
					tiles.Add (tile);
				}
			}
		}
	}

	/*
	 * Puts a new strip of tiles on the specified direction and removes a strip from the opposite side
	 */
	void MoveEdgeTiles(int dir, List<GameObject> newTiles){
		switch (dir) {

		case GameMasterBehavior.NORTH:
			
			//Remove strip from the South side
			for (int i = tiles.Count - idMap.GetLength (1); i < tiles.Count; i++) {
				Destroy (((GameObject)tiles [i]));
			}

			//Remove references from tile List
			tiles.RemoveRange (tiles.Count - idMap.GetLength (1), idMap.GetLength (1));

			//Anchor position of where to place new tiles
			Vector3 iPos0 = tiles [0].GetComponent<Transform> ().position;

			//Correct the position of the new tiles based on the anchor
			for (int i = 0; i < newTiles.Count; i++) {
				newTiles [i].GetComponent<Transform> ().position = (new Vector3 (-tileWidth,0,i*tileWidth)+iPos0);
			}

			//Add the tiles to the List
			tiles.InsertRange (0, newTiles);

			break;

		case GameMasterBehavior.SOUTH:

			//Remove strip from North side
			for (int i = 0; i < idMap.GetLength (1); i++) {
				Destroy (((GameObject)tiles [i]));
			}

			//Remove references from tile List
			tiles.RemoveRange (0, idMap.GetLength (1));

			//Anchor position of where to place new tiles
			Vector3 iPos1 = tiles [tiles.Count-idMap.GetLength(1)].GetComponent<Transform> ().position;

			//Correct the position of the new tiles
			for (int i = 0; i < newTiles.Count; i++) {
				newTiles [i].GetComponent<Transform> ().position = (new Vector3 (tileWidth,0,i*tileWidth)+iPos1);
			}

			//Add the tiles to the List
			tiles.InsertRange (tiles.Count, newTiles);

			break;

		case GameMasterBehavior.EAST:

			//Anchor position of where to place new tiles
			Vector3 iPos3 = tiles [idMap.GetLength(1)-1].GetComponent<Transform> ().position;

			//Destroy tiles from West side
			for (int i = tiles.Count-idMap.GetLength(1); i >= 0; i -= idMap.GetLength(1)) {
				Destroy (((GameObject)tiles [i]));
			}

			//Remove references of dead tiles from List
			for (int i = tiles.Count-idMap.GetLength(1); i >= 0; i -= idMap.GetLength(1)) {
				tiles.RemoveAt (i);

			}

			//Correct the position of the new tiles and put them into List
			for (int i = 0; i < newTiles.Count; i++) {
				newTiles [i].GetComponent<Transform> ().position = (new Vector3 (i*tileWidth,0,tileWidth)+iPos3);
				tiles.Insert (idMap.GetLength(1)-1+(i*idMap.GetLength(1)), newTiles[i]);
			}

			break;

		case GameMasterBehavior.WEST:

			//Destroy tiles from East side
			for (int i = tiles.Count-1; i >= 0; i -= idMap.GetLength(1)) {
				Destroy (((GameObject)tiles [i]));
			}

			//Remove references to dead tiles
			for (int i = tiles.Count-1; i >= 0; i -= idMap.GetLength(1)) {
				tiles.RemoveAt (i);
			}

			//Anchor position of where to place new tiles
			Vector3 iPos2 = tiles [0].GetComponent<Transform> ().position;

			//Correct the position of the new tiles and put them into the List
			for (int i = 0; i < newTiles.Count; i++) {
				newTiles [i].GetComponent<Transform> ().position = (new Vector3 (i*tileWidth,0,-tileWidth)+iPos2);
				tiles.Insert (i*idMap.GetLength(1), newTiles[i]);
			}

			break;
		}			
	}
}
