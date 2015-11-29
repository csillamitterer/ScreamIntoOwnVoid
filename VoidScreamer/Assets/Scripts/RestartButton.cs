using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {
	public void Restart() {
		Application.LoadLevel("Game");
	}

	public void Quit() {
		Application.Quit ();
	}
}