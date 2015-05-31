using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour {
	private float min=2f;
	private float max=3f;
	// Use this for initialization
	void Start () {
		min=transform.position.x;
		max=transform.position.x+10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =new Vector3(Mathf.PingPong (Time.time * 6, max - min) + min, transform.position.y, transform.position.z);
	}
}
