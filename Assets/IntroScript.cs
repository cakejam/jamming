using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScript : MonoBehaviour {

	private int w = 550;
	private int h = 100;
	private Rect textArea;
	private GUIStyle style;
	private Color textColor;
	private string message;
	private ArrayList introMessages = new ArrayList();
	bool showMessage = true;
	bool showNextMessage = true;
	bool showLastMessage = false;
	int timer = 0;

	// Use this for initialization
	void Start () {
		style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 36;
		style.wordWrap = true;
		textColor = Color.white;
		textColor.a += 0.5f * Time.deltaTime;;
		style.normal.textColor = textColor;
		textArea = new Rect(0, 0, Screen.width, Screen.height);
		
		introMessages.Add("...Where am I?....");
		introMessages.Add("I feel like shit.....");
		introMessages.Add("Is this my house?");
		introMessages.Add("I need to go inside and lie down");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (showMessage){
			message = (string)introMessages[0];
			if (showNextMessage){
				introMessages.RemoveAt(0);
				if (introMessages.Count == 0){
					showMessage = false;
					showLastMessage = true;
					message = "I need to go inside and lie down";
				}
				else{
					message = (string)introMessages[0];
				}
			}
			GUI.Label(textArea, message, style);
			if (showNextMessage){
				StartCoroutine(showMessageTimer());
				showNextMessage = false;
			}

		}
		if (showLastMessage){
			message = "I need to go inside and lie down";
			GUI.Label(textArea, message, style);
		}
	}

	IEnumerator showMessageTimer(){
		yield return new WaitForSeconds(3);
		Debug.Log ("end");
		showNextMessage = true;
	}
}
