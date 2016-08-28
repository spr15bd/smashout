using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Status : MonoBehaviour {
	public int lives, score, hiscore;
	private Text hiScore;
	public void Awake() {
		DontDestroyOnLoad(this);
	}
	public void Start() {
		print ("Status is starting");
	}	
}
