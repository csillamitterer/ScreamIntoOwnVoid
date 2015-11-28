using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {
	public float speedFactor = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (transform.forward * Time.deltaTime * speedFactor);
	}
}
