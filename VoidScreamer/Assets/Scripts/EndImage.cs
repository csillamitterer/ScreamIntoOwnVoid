using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndImage : MonoBehaviour {
	public string imageType;

	void EndGame(string type) {
		if (imageType == type) {
			gameObject.GetComponent<Image>().enabled = true;
		}
	}
}
