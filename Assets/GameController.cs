using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	int bronzePlayer;
	int silverPlayer;
	int bronzeSupply;
	int silverSupply;
	int miningSpeed;
	int timeToMine;
	float xPosition;

	public GameObject cubePrefab;



	Vector3 cubePosition;
	GameObject currentCube;

//	int Random.Range (int minimum, int maximum) {
//		
//	}

	// Use this for initialization
	void Start () {
		bronzePlayer = 0;
		silverPlayer = 0;
		miningSpeed = 2;
		bronzeSupply = 3;
		silverSupply = 2;
		timeToMine = 1;

	}


	// Update is called once per frame
	void Update () {

		if (Time.time > timeToMine) {
			// mine some ore, and update how many ore the player has


			// only mine bronze, if we have at least 1 in the supply
			if (bronzeSupply > 0) {
				bronzeSupply -= 1;
				bronzePlayer += 1;
	

				cubePosition = new Vector3 (Random.Range(-5, 5), Random.Range(-5, 5),0);
				currentCube = Instantiate (cubePrefab, cubePosition, Quaternion.identity);
				xPosition += 2;

				currentCube.GetComponent<Renderer> ().material.color = Color.red;

			}

			// only mine silver, if there's no bronze in supply AND we have at least 1 silver
			else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				silverPlayer += 1;

				cubePosition = new Vector3 (Random.Range(-5, 5), Random.Range(-5, 5),0);
				currentCube = Instantiate (cubePrefab, cubePosition, Quaternion.identity);
				xPosition += 2;

				currentCube.GetComponent<Renderer> ().material.color = Color.white;
			}

			// make sure we wait another miningSpeed seconds before mining again

			// tell the player how much ore they have
			print ("Bronze: " + bronzePlayer + " Silver: " + silverPlayer);

			timeToMine += miningSpeed;

		}

	}
}

