using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
//	初始化定时器
	private float Timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer > 0.5f) {
			transform.position += new Vector3 (0f, 0f, 1f);	
			Timer = 0f;
		}
	}
}
