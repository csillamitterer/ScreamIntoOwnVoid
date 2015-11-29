using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour {
	MeshRenderer render;
	public float xSpeed;
	public float ySpeed;

	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		render.material.mainTextureOffset = new Vector2 (Time.time * xSpeed % 1, Time.time * ySpeed % 1);
	}
}
