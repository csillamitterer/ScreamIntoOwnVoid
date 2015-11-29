using UnityEngine;
using System.Collections;

public class EndVO : MonoBehaviour {
	public string endType;
	
	void EndGame(string type) {
		if (endType == type) {
			gameObject.GetComponent<AudioSource>().Play();
		}
	}
}
