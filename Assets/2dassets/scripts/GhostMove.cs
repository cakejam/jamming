using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {

	public float speed = 6.0f;
	private float defaultSpeed = 6.0f;
	private float fasterSpeed = 10.0f;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float playerX = GameObject.Find("player").transform.position.x;
		if (position.x - playerX > 20) {
			speed = defaultSpeed;
			position.x += -40;
		} else if (position.x - playerX > 10) {
			speed = fasterSpeed;
		} 
		var x_auto = Time.deltaTime * speed;
		position.x += x_auto;
		transform.position = new Vector3 (position.x, position.y + Mathf.Sin (Time.time * speed), position.z);
	}
}