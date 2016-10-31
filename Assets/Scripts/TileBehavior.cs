using UnityEngine;
using System.Collections;

/*
 * The Tile Class
 * 		The subclass for all tiles in the game. Tiles keep track of their own movement.
 * 
 * 		To make a new tile, feel free to extend this class. Make sure to also:
 * 			-Create and save a new tile prefab in prefab folder
 * 			-Add reference to prefab to TileLayerBehavior script
 */
public class TileBehavior : MonoBehaviour {

	private float speed;


	void Start () {
		speed = GameMasterBehavior.speed;
	}
	

	void Update () {
		if (GameMasterBehavior.isUp) {
			transform.Translate(new Vector3(-1f*speed,0,0));
		}
		if (GameMasterBehavior.isDown) {
			transform.Translate(new Vector3(1f*speed,0,0));
		}
		if (GameMasterBehavior.isLeft) {
			transform.Translate(new Vector3(0,0,-1f*speed));
		}
		if (GameMasterBehavior.isRight) {
			transform.Translate(new Vector3(0,0,1f*speed));
		}
	}


}
	