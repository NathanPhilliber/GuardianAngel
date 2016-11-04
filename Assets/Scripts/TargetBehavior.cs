using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	public float speed = .5f;
	public int direction = -1;
	public Collider north;
	public Collider south;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveInCorrectDirection ();
	}

	void MoveInCorrectDirection(){



		if (TargetTriggerBehavior.eastTriggered) {
			direction = GameMasterBehavior.EAST;
			north.GetComponent<Collider>().enabled = true;
			south.GetComponent<Collider>().enabled = true;
		} else {
			if (TargetTriggerBehavior.northTriggered) {
				direction = GameMasterBehavior.NORTH;
				north.GetComponent<Collider> ().enabled = true;
				south.GetComponent<Collider> ().enabled = false;
			} else if (TargetTriggerBehavior.southTriggered) {
				direction = GameMasterBehavior.SOUTH;
				north.GetComponent<Collider> ().enabled = false;
				south.GetComponent<Collider> ().enabled = true;
			} else {
				direction = -1;
				north.GetComponent<Collider>().enabled = true;
				south.GetComponent<Collider>().enabled = true;
			}

		}
		
		switch (direction) {
		case GameMasterBehavior.NORTH:
			transform.Translate (new Vector3(-speed,0,0));
			break;
		case GameMasterBehavior.EAST:
			transform.Translate (new Vector3(0,0,speed));
			break;
		case GameMasterBehavior.SOUTH:
			transform.Translate (new Vector3(speed,0,0));
			break;
		}
	}


		
}
