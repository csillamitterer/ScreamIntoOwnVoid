using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameMessage : MonoBehaviour {

	void EndGame(string message) {
		gameObject.GetComponent<Text> ().text = message;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
