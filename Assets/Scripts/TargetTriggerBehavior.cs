using UnityEngine;
using System.Collections;

public class TargetTriggerBehavior : MonoBehaviour {

	public TargetBehavior parent;
	public int direction;
	public Collider other1;
	public Collider other2;
	int directionChangeCooldown;
	public int directionChangeCoolDownMin;
	public static bool eastTriggered;
	public static bool northTriggered;
	public static bool southTriggered;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		directionChangeCooldown++;
	}

	//problem is that when west is updated north/south is immediately retriggered

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



	void OnTriggerStay(Collider other){
		
		//tell mommy that you got hit

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
