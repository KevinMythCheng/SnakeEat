using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
//	初始化定时器
	private float Timer;
//	初始化方向
	private Vector3 Driver;
//	Body预设值
	public GameObject preBodys;
//	BodyBones 数组
	private GameObject[] bodys;
//	蛇身体的长度
	public int counts;
//	蛇是否死亡
	public bool isDead = false;
//	自定义吃蛋音效
	private AudioSource eatAudio;
	// Use this for initialization
	void Start () {
		Driver = Vector3.forward;
//		最多100个长度
		bodys = new GameObject[100];
		bodys[0] = gameObject;
		bodys [1] = preBodys;
		counts = 2;
		eatAudio = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Driver = currentDriver ();
		Timer += Time.deltaTime;
		if (Timer > 0.5f) {
			track ();
			transform.position += Driver;	
			Timer = 0f;
		}

	}

//	蛇碰到蛋之后增加身体长度
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Egg") {
			eatAudio.Play();
			addBodyLength ();
		}
		if (other.gameObject.tag == "Wall") {
			Driver = Vector3.zero;
			isDead = true;
		}
	}

	Vector3 currentDriver (){
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ) {
			return  Vector3.forward ;
		} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			return Vector3.back ;
		} else if (Input.GetKeyDown (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			return Vector3.left ;
		} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			return Vector3.right ;
		} else {
			return Driver;
		}
	}
		

	void track () {
		if (!isDead) {
			for (int i = counts - 1; i > 0; i--) {
				bodys [i].transform.position = bodys [i - 1].transform.position;
			}
		}

	}

	void addBodyLength(){
//		if(Input.GetKeyDown(KeyCode.E)){
			bodys[counts] = GameObject.Instantiate (preBodys);
			counts++;
//		}
	}
}
