using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
//	引用两个标签
	public Text ScoreLabel;
	public Text DeadLabel;
//	自定义分数
	private int score;
//	自定义蛇身和脚本
	private GameObject snake;
	private PlayerController playerController;
//	自定义死亡音效
	public AudioClip deadClip;
//	自定义背景音乐
	private AudioSource BGMMusic;
	// Use this for initialization
	void Start () {
		snake = GameObject.FindGameObjectWithTag ("Player");
		playerController = snake.GetComponent<PlayerController> ();
		BGMMusic = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			print ("Exit");
			Application.Quit ();
		}

		score = playerController.counts - 2;
		ScoreLabel.text = "Score :" + score.ToString ();

		if(playerController.isDead) { 
			DeadLabel.text = "You Dead!";
			if (BGMMusic.isPlaying) {
				BGMMusic.Stop ();
				AudioSource.PlayClipAtPoint (deadClip, transform.position);	
			}
		}

	}
}
