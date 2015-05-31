using UnityEngine;
using System.Collections;

public class HealPlayer : MonoBehaviour {

	public int amount = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag("Player")) {
			Destroy(this.gameObject);
		}
	}
}
