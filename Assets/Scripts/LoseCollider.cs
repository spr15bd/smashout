using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private Status status;
	private LevelManager levelManager;
	private Text lives;
	public Ball newBall;
	
	
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		status = GameObject.FindObjectOfType<Status>();
		lives = GameObject.Find("Lives").GetComponent<Text>();
		lives.text = status.lives.ToString();
		int numberOfBalls = GameObject.FindGameObjectsWithTag("Ball").Length;
		print("Number of ball objects at start = "+numberOfBalls);
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}
	
	
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Ball Trigger.");
		if(trigger.gameObject.tag == "Ball")
		{
			Destroy(trigger.gameObject);
			print ("This is a ball tag");
			Ball.ballsCount--;
			print("Ballscount = "+Ball.ballsCount);
			int numberOfBalls = GameObject.FindGameObjectsWithTag("Ball").Length;
			print("Number of ball objects before hit loseCollider = "+numberOfBalls);
			Destroy(trigger);

			print("Number of ball objects after hit loseCollider = "+numberOfBalls);
			//if (Ball.ballsCount<=0) {
			if (numberOfBalls<=1) {
				print ("lives are coming off");
				status.lives--;
				lives.text = status.lives.ToString();
				
				//if (status.lives<=0) {
				if (status.lives<=0) {
					//load lose screen, reset variables
					print("Number of ball objects at gameover = "+numberOfBalls);
					print ("It's game over");
					if (status.score > status.hiscore) {
						status.hiscore = status.score;
					}
					levelManager.LoadLevel("LoseScreen");
					status.score=0;
					status.lives=3;
					Brick.breakableCount = 0;
				} else {
					print("New ball");
					//newBall = 
					//newBall = GameObject.FindObjectOfType<Ball>();
					Ball ball = Instantiate(newBall, new Vector3 (5f, 5f, 0f), Quaternion.identity) as Ball;
					ball.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				}
			} else {
				//print ("Ballscount = "+Ball.ballsCount);
			}
		} else {
			Destroy (trigger);
		}
		
		
	}
}
