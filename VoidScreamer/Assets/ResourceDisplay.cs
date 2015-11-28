using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour {
	public GameObject none;
	public GameObject low;
	public GameObject medium;
	public GameObject high;
	
	public Slider Tracking;

	// Use this for initialization
	void Start () {
		none = transform.Find ("None").gameObject;
		low = transform.Find ("Low").gameObject;
		medium = transform.Find ("Medium").gameObject;
		high = transform.Find ("High").gameObject;

	}
	
	// Update is called once per frame
	void Update () {

		if (Mathf.Approximately(Tracking.normalizedValue, 0)) { // empty
			none.SetActive (true);
			low.SetActive (false);
			medium.SetActive (false);
			high.SetActive (false);
		} else if (Mathf.Approximately(Tracking.normalizedValue, 1)) { // full
			none.SetActive (false);
			low.SetActive (false);
			medium.SetActive (false);
			high.SetActive (true);
		} else if (Tracking.normalizedValue < 0.5) { // low
			none.SetActive (false);
			low.SetActive (true);
			medium.SetActive (false);
			high.SetActive (false);
		} else { // medium
			none.SetActive (false);
			low.SetActive (false);
			medium.SetActive (true);
			high.SetActive (false);
		}

	}
}
