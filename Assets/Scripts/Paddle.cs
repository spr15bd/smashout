using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	// Use this for initialization
	public bool automaticPlayer = false;
	public float minX, maxX;
	private Ball ball;
	
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		//Cursor.visible = false;
		Ball.ballsCount = 0;
	}
	// Update is called once per frame
	void Update () {
		if (!automaticPlayer) {	
			MoveWithMouse ();
		} else {
			AutomaticPlayer();
		}
	}
	void AutomaticPlayer() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = (Input.mousePosition.x/Screen.width)*16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
