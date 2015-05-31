using UnityEngine;
using System.Collections;

public class ArrowLeft : MonoBehaviour {
	Vector3 startPosition;
	public float springFactor = 8f;
	
	void Start () {
		GetComponent<Renderer>().enabled = false;
		startPosition = this.transform.position;
		Flip ();
		StartCoroutine (Shoot());
	}
	
	IEnumerator Shoot(){
		while (true) {
			yield return new WaitForSeconds(1.7f);
			GetComponent<Renderer>().enabled = true;
			this.transform.position = startPosition;
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-30, 0, 0);
		}
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
