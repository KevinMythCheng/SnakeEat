using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject head;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		print ("start");
		offset = transform.position- head.transform.position ;
	}
	
	// Update is called once per frame
	void Update () {
//		平滑过渡 

		transform.position = Vector3.Lerp (transform.position, head.transform.position + offset, 0.2f);
	}
}
