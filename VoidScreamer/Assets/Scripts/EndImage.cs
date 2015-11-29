﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndImage : MonoBehaviour {
	public string endType;

	void EndGame(string type) {
		if (endType == type) {
			gameObject.GetComponent<Image>().enabled = true;
		}
	}
}
