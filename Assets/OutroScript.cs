using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutroScript : MonoBehaviour {
	
	private int w = 550;
	private int h = 100;
	private Rect textArea;
	private GUIStyle style;
	private Color textColor;
	private string message;
	private ArrayList outroMessages = new ArrayList();
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

		outroMessages.Add("....");
		outroMessages.Add("...WTF...");
		outroMessages.Add("I'm never drinking again.");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(0);
		}
	}
	
	void OnGUI()
	{
		if (showMessage){
			message = (string)outroMessages[0];
			if (showNextMessage){
				outroMessages.RemoveAt(0);
				if (outroMessages.Count == 0){
					showMessage = false;
					showLastMessage = true;
					message = "I'm never drinking again.";
				}
				else{
					message = (string)outroMessages[0];
				}
			}
			GUI.Label(textArea, message, style);
			if (showNextMessage){
				StartCoroutine(showMessageTimer());
				showNextMessage = false;
			}
			
		}
		if (showLastMessage){
			message = "I'm never drinking again.\n (Press R to restart)";
			GUI.Label(textArea, message, style);
		}
	}
	
	IEnumerator showMessageTimer(){
		yield return new WaitForSeconds(3);
		Debug.Log ("end");
		showNextMessage = true;
	}
}
