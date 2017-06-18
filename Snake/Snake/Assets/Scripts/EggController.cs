using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {
//	引用预设体
	public GameObject egg;
//	自定义计时器
//	private float timer = 0f;
	
	// Update is called once per frame
	void Update () {
//		timer += Time.deltaTime;
//		if (timer > 1f) {
//			RandomEgg ();
//		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			UnityEngine.Object.Destroy (gameObject);
			RandomEgg ();
		}
	}
	void RandomEgg () {
		GameObject newEgg = GameObject.Instantiate (egg);
		float x = Random.Range (-23f, 23f);
		float z = Random.Range (-23f, 23f);
		newEgg.transform.position = new Vector3 (x, 0.5f, z);
	}
}
