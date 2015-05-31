using UnityEngine;
using System.Collections;

public class CupidLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Flip ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
