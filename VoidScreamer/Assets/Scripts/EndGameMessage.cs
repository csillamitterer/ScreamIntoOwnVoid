using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameMessage : MonoBehaviour {

	void EndGame(string type) {
		if (type == "Fuel") {
			gameObject.GetComponent<Text> ().text = "YOU RAN OUT OF FUEL\n\n\nYOU LOSE";
		} else if (type == "Population") {
			gameObject.GetComponent<Text> ().text = "EVERYONE DIED\n\n\n\nYOU LOSE";
		} else if (type == "Food") {
			gameObject.GetComponent<Text> ().text = "EVERYONE DIED\n\n\n\nYOU LOSE";
		} else if (type == "Water") {
			gameObject.GetComponent<Text> ().text = "EVERYONE DIED\n\n\n\nYOU LOSE";
		} else if (type == "Win") {
			gameObject.GetComponent<Text> ().text = "WELL DONE\n\n\n\nYOU WIN";
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
