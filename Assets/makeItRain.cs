using UnityEngine;
using System.Collections;

public class makeItRain : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.2f);
		if (Random.value < 0.5f) {
			transform.position = new Vector2 (transform.position.x + 0.01f, transform.position.y - 0.2f);
		} else {
			transform.position = new Vector2 (transform.position.x - 0.01f, transform.position.y - 0.2f);
		}
		if (transform.position.y < player.transform.position.y - 16) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + 24);
		}
	}
}
