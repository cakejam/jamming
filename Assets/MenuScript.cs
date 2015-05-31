using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	private int w = 550;
	private int h = 100;
	private Rect textArea1;
	private Rect textArea2;
	private GUIStyle style1;
	private GUIStyle style2;
	private Color textColor;
	private string message;

	bool showMessage1 = true;
	bool showMessage2 = false;
	bool timerStarted = false;
	bool blinkTimer = false;
	
	// Use this for initialization
	void Start () {
		style1 = new GUIStyle();
		style1.alignment = TextAnchor.MiddleCenter;
		style1.fontSize = 150;
		style1.wordWrap = true;
		textColor = Color.red;
		textColor.a += 0.5f * Time.deltaTime;;
		style1.normal.textColor = textColor;
		style2 = style1;
		style2.fontSize = 36;

		textArea1 = new Rect(0, 0, Screen.width, 150);
		textArea2 = new Rect(0, 200, Screen.width, 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel(1);
		}
	}
	
	void OnGUI()
	{
		message = "Hangover From Hell";
		GUI.Label(textArea1, message, style1);

		if (!showMessage2 && !timerStarted){
			StartCoroutine(showMessageTimer());
			timerStarted = true;
		}
		else if (showMessage2){
			if (!blinkTimer){
				StartCoroutine(showMessageTimer());
				blinkTimer = true;
			}

			message = "Press Any Key to Start";
			GUI.Label(textArea2, message, style2);
		}
		else if (blinkTimer){
			blinkTimer = false;
			StartCoroutine(showMessageTimer());
		}
	}
	
	IEnumerator showMessageTimer(){
		Debug.Log ("start");
		yield return new WaitForSeconds(1);
		Debug.Log ("end");
		showMessage2 = !showMessage2;

	}
}
