using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private LevelManager levelManager;
	public bool levelStart = false;
	private Vector3 paddleToBallVector;
	public static int ballsCount = 0;

	// Use this for initialization
	void Start () {
		ballsCount++;
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//22/06/16if (!hasStarted) {
		if (levelManager.levelStarted) {
			// Lock the ball's vector position relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			// Wait for a mouse press to launch
			if (Input.GetMouseButton(0)) {
				levelManager.levelStarted = false;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		} else {
			if (Math.Abs (this.GetComponent<Rigidbody2D>().velocity.x) < 0.2f) {
				this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (30f, 0));
			}
			if (Math.Abs (this.GetComponent<Rigidbody2D>().velocity.y) < 0.2f) {
				this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 30f));
			}
		}
	}
		
	void OnCollisionEnter2D (Collision2D col) {
		// Ball may not always trigger sound when brick is destroyed
		if (!levelManager.levelStarted) {
			GetComponent<AudioSource>().Play ();
		}
		//if (col.gameObject.tag == "LoseZone") {
		//	Destroy (this.gameObject);
		//	print("Collision in ball script");
		//}
	}

	/*void OnTriggerEnter2D (Collider2D other) {
		//print ("Ball Trigger.");
		if (other.gameObject.tag == "LoseZone") {
			Destroy (this.gameObject);
			print("Collision in ball script");
		}
	}*/
}
