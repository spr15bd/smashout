using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	private int timesHit;
	private LevelManager levelManager;
	private Status status;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	public GameObject smoke;
	public GameObject pow;
	public int scoreValue;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		status = GameObject.FindObjectOfType<Status>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		scoreText.text = status.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.2f);
		
		if (isBreakable) {
			HandleHits();
		}
		
		
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.2f);
		
		if (isBreakable) {
			timesHit+=2;
			HandleHits();
		}
		
		
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			//Debug.Log ("brcount = "+breakableCount);
			levelManager.BrickDestroyed();
			SmokePuff ();
			
			Destroy (gameObject);
			status.score+=scoreValue;
			//print ("status score: "+status.score);
			scoreText.text = status.score.ToString();
		} else {
			LoadSprites();
		}
	}
	
	void SmokePuff() {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		if (Random.Range(0, 1f) <0.2f) {
			// with probability 0.2, create a powerup
			Instantiate(pow, transform.position, Quaternion.identity);
		}
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		// Test there is a spite at the particular index to avoid missing sprites
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			print("Sprite is missing");
		}
	}
}
