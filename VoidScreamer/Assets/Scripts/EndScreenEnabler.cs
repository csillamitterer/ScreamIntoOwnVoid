using UnityEngine;
using System.Collections;

public class EndScreenEnabler : MonoBehaviour {

	void EndGame() {
		gameObject.GetComponent<CanvasGroup> ().interactable = true;
		gameObject.GetComponent<CanvasGroup> ().alpha = 1;
		gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
