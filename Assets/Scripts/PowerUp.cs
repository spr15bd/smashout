using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUp : MonoBehaviour {
	private Ball newBall;
	private Paddle paddle;
	private Brick[] bricks;
	private Status status;
	private int scoreValue=10;	//10 points for getting a powerup
	private Text scoreText;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
		status = GameObject.FindObjectOfType<Status>();
		scoreText = GameObject.Find("Score").GetComponent<Text>();
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		if(trigger.gameObject.tag == "Player")
		{
			print ("powerup Trigger");
			status.score+=scoreValue;
			scoreText.text = status.score.ToString();
			if (this.gameObject.tag == "ExtraBall") {
				print ("Extraball tag found");

				newBall = GameObject.FindObjectOfType<Ball>();
				// 23/6/16 above line is not working on one column of level 2
				//newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				//newBall.hasStarted = true;
				Ball ball = Instantiate(newBall, transform.position+new Vector3 (2f, 10f, 0f), Quaternion.identity) as Ball;
				ball.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			} else if (this.gameObject.tag == "BigBat") {
				paddle = GameObject.FindObjectOfType<Paddle>();
				paddle.transform.localScale = new Vector3(1.2f,1f,1f);
			} else if (this.gameObject.tag == "Through") {
				bricks = GameObject.FindObjectsOfType<Brick>();
				
				for (int f=0; f<bricks.Length; f++) {
					bricks[f].transform.GetComponent<Collider2D>().isTrigger = true;
				}
			}
		
			Destroy (this.gameObject);
		}
	}
}