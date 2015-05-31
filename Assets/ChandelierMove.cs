using UnityEngine;
using System.Collections;

public class ChandelierMove : MonoBehaviour {
	
	public float speed = 12.0f;
	private Vector3 startPosition;
	private bool fall = false;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float playerX = GameObject.Find("player").transform.position.x;
		if (startPosition.x - playerX < 5) {
			fall = true;
		}
		if(fall) {
			var y_auto = Time.deltaTime * speed;
			startPosition.y += -y_auto;
			transform.position = new Vector3 (startPosition.x, startPosition.y, startPosition.z);
		}
	}
}