using UnityEngine;
using System.Collections;

public class SlasherMove : MonoBehaviour {
	private float min=2f;
	private float max=3f;
	private float previous;
	private bool increasing = false;
	// Use this for initialization
	void Start () {
		min=transform.position.x;
		max=transform.position.x+12;
		previous = min;
	}
	
	// Update is called once per frame
	void Update () {
		float xpos = Mathf.PingPong (Time.time * 6, max - min) + min;
		if ((xpos - previous > 0 && !increasing) || (xpos - previous < 0 && increasing)) {
			increasing = !increasing;
			Flip();
		}
		previous = xpos;
		transform.position =new Vector3(xpos, transform.position.y, transform.position.z);
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
