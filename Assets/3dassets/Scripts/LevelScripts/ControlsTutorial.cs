using UnityEngine;
using System.Collections;

public class ControlsTutorial : MonoBehaviour
{
	private string message = "";
	//private ArrayList<string> introMessages = new ArrayList<string>();
	//private ArrayList<string> outroMessages = new ArrayList<string>();
	private bool showMsg = false;

	private int w = 550;
	private int h = 100;
	private Rect textArea;
	private GUIStyle style;
	private Color textColor;


	void Awake()
	{
		style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 36;
		style.wordWrap = true;
		textColor = Color.white;
		textColor.a = 0;
		textArea = new Rect((Screen.width-w)/2, 0, w, h);

		/*introMessages.Add("...Where am I?....");
		introMessages.Add("I feel like shit.....");
		introMessages.Add("Is this my house?");
		introMessages.Add("I need to go inside and lie down");
		outroMessages.Add(".....");
		outroMessages.Add("I'm never drinking again.");*/
	}

	void Update()
	{
		/*if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			Screen.lockCursor = true;
			Cursor.visible = false;
		}
		if (Input.GetKeyDown("escape"))
		{
			Screen.lockCursor = false;
			Cursor.visible = true;
		}*/
	}

	void OnGUI()
	{
		if(showMsg)
		{
			if(textColor.a <= 1)
				textColor.a += 0.5f * Time.deltaTime;
		}
		// no hint to show
		else
		{
			if(textColor.a > 0)
				textColor.a -= 0.5f * Time.deltaTime;
		}

		style.normal.textColor = textColor;

		GUI.Label(textArea, message, style);
	}

	public void setShowMsg(bool show)
	{
		showMsg = show;
	}

	public void setMessage(string msg)
	{
		message = msg;
	}
}
