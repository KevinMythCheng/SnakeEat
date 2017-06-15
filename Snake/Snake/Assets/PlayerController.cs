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
	private int counts;
	// Use this for initialization
	void Start () {
		Driver = Vector3.forward;
//		最多100个长度
		bodys = new GameObject[100];
		bodys[0] = gameObject;
		bodys [1] = preBodys;
		counts = 2;
	}
	
	// Update is called once per frame
	void Update () {
		addBodyLength ();
		Driver = currentDriver ();
		Timer += Time.deltaTime;
		if (Timer > 0.5f) {
			track ();
			transform.position += Driver;	
			Timer = 0f;
		}

	}

	Vector3 currentDriver (){
		if (Input.GetKeyDown (KeyCode.W)) {
			return  Vector3.forward;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			return Vector3.back;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			return Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			return Vector3.right;
		} else {
			return Driver;
		}
	}

	void track () {
		for (int i = counts - 1; i > 0; i--) {
			bodys [i].transform.position = bodys [i - 1].transform.position;
		}
	}

	void addBodyLength(){
		if(Input.GetKeyDown(KeyCode.E)){
			bodys[counts] = GameObject.Instantiate (preBodys);
			counts++;
		}
	}
}
