using UnityEngine;
using System.Collections;

public class waitToPeak : MonoBehaviour {
	public Sprite peak;
	private SpriteRenderer sr;
	private bool peaked = false;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hitDatShit.timeToPeak) {
			if (sr.sprite != peak) {
				peaked = true;
				sr.sprite = peak;
				GetComponent<Animator>().enabled = false;
				float desiredScale = 0.3f; // your scale factor
				transform.localScale = new Vector2( desiredScale, desiredScale);
			}
		} else if (peaked) {
			GetComponent<Animator>().enabled = true;
			peaked = false;
			transform.localScale = new Vector2( 1.0f, 1.0f);
		}

	}
}
