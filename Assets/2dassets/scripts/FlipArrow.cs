using UnityEngine;
using System.Collections;

public class FlipArrow : MonoBehaviour {
	Vector3 startPosition;
	private int count = 0;
	private int xveloc = 30;
	
	public float springFactor = 8f;
	
	void Start () {
		GetComponent<Renderer>().enabled = false;
		startPosition = this.transform.position;
		StartCoroutine (Shoot());
	}
	
	IEnumerator Shoot(){
		while (true) {
			yield return new WaitForSeconds(1.7f);
			GetComponent<Renderer>().enabled = true;
			this.transform.position = startPosition;
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (xveloc, 0, 0);
			count++;
			if (count == 2) {
				Flip ();
				count = 0;
			}
		}
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		xveloc = -xveloc;
	}
}
