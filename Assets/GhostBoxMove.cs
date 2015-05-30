using UnityEngine;
using System.Collections;

public class GhostBoxMove : MonoBehaviour {
	public float speed = 10.0f;
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var x_auto = Time.deltaTime*speed;
		startPosition.x += -x_auto;
		transform.position = new Vector3 (startPosition.x, startPosition.y, startPosition.z);
	}
}
