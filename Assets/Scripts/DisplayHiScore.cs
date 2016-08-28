using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHiScore : MonoBehaviour {
	private Text hi;
	private Status status;

	// Use this for initialization
	void Start () {
		status = GameObject.FindObjectOfType<Status>();
		hi = GetComponent<Text>();
		hi.text = status.hiscore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		hi.text = status.hiscore.ToString ();
	}
}
