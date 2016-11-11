using UnityEngine;
using System.Collections;

public class TargetTriggerBehavior : MonoBehaviour {

	public TargetBehavior parent;
	public int direction;
	public Collider other1; //Top colllider
	public Collider other2; //Next collider
	public static bool eastTriggered;
	public static bool northTriggered;
	public static bool southTriggered;

	//Update direction booleans
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Path")) {
			if (direction == GameMasterBehavior.NORTH) {
				northTriggered = false;
			} else if (direction == GameMasterBehavior.EAST) {
				eastTriggered = false;
			} else if (direction == GameMasterBehavior.SOUTH) {
				southTriggered = false;
			}

		}
	}


	//Update direction booleans
	void OnTriggerStay(Collider other){

		if (other.CompareTag ("Path")) {
			

			if (direction == GameMasterBehavior.NORTH) {
				northTriggered = true;
			}
			else if (direction == GameMasterBehavior.EAST) {
				eastTriggered = true;
			}
			else if (direction == GameMasterBehavior.SOUTH) {
				southTriggered = true;
			}

		}

	}
}
