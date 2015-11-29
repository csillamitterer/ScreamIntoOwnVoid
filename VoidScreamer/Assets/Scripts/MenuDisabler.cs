using UnityEngine;
using System.Collections;

public class MenuDisabler : MonoBehaviour {

	void EndGame() {
		gameObject.GetComponent<CanvasGroup> ().interactable = false;
	}
}
