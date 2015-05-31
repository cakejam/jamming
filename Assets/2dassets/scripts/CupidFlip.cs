using UnityEngine;
using System.Collections;

public class CupidFlip : MonoBehaviour {

	private int count = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (Counter());
	}

	IEnumerator Counter(){
		while (true) {
			yield return new WaitForSeconds(1.7f);
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
	}
}
