using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathLayerBehavior : TileLayerBehavior
{
	/*
	 * Struct to store sets of coordinates for path tiles 
	 */
	public struct CoordSet
	{
		public int z, x;
		public CoordSet(int z, int x){
			this.z = z;
			this.x = x;
		}
	}

	//List of path tile coord sets
	private List<CoordSet> path;

	//The target GameObject
	public GameObject target;

	// Use this for initialization
	protected void Start ()
	{
		//Initialize tiles List, stores path tile object
		tiles = new List<GameObject> ();

		//Initialize paths coord sets to a straight lines to the right
		path = new List<CoordSet> ();
		for (int i = 0; i < 25; i++) {
			path.Add (new CoordSet(i,0));
		}
		RebuildTileMap ();
	}

	//Override tile layer method, places the tiles from the coord sets List
	protected void RebuildTileMap ()
	{
		for (int i = 0; i < path.Count; i++) {
			
			tiles.Add((GameObject)Instantiate (GameMasterBehavior.tilePalete [3], new Vector3 (path[i].x*tileWidth, yOffset, path[i].z*tileWidth), Quaternion.identity));
		}
	}

	public override void Move(int dir){
		//Don't worry about the direction variable. The path decides where the direction will eventually go!


		//Get the last path, build east of that, then +- random number of tiles north and south
		if (tiles.Count < 200 || path[path.Count/2].z*3*tileWidth >= target.transform.position.z) {
			int oldX = path [path.Count - 1].x;
			int oldZ = path [path.Count - 1].z;

			int numOnXAxis = Random.Range (-10, 11) / Random.Range (1, 8);

			//Decide how far to move on the x axis, then move over one on the z axis
			for (int i = 0; i < Mathf.Abs (numOnXAxis); i++) {
				if (i == 0 || i == 1) {
					path.Add (new CoordSet (oldZ + 1 + i, oldX));

				} else {
					path.Add (new CoordSet (oldZ + 2, oldX + (i - 2) * (int)Mathf.Sign (numOnXAxis)));

				}

				tiles.Add ((GameObject)Instantiate (GameMasterBehavior.tilePalete [3], new Vector3 (path [path.Count - 1].x * tileWidth, yOffset, path [path.Count - 1].z * tileWidth), Quaternion.identity));
				if ((tiles.Count > 100 && path[path.Count/2].z*tileWidth <= target.transform.position.z)) {
					Destroy (tiles [0]);
					tiles.RemoveAt (0);
					path.RemoveAt (0);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
