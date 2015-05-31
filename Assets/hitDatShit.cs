using UnityEngine;
using System.Collections;

public class hitDatShit : MonoBehaviour {
	static public bool timeToPeak = false;
	public AudioClip getMoney;
	public AudioClip theTrack;
	public Sprite on; // Drag your first sprite here
	public Sprite off; // Drag your second sprite here
	private SpriteRenderer spriteRenderer; 
	private AudioSource audio; 

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		TogglePax();
	}

	void TogglePax ()
	{
		if (spriteRenderer.sprite == off) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = on;
			audio.Stop();
			audio.clip = theTrack;
			audio.Play();
			timeToPeak = true;
		}
		else
		{
			spriteRenderer.sprite = off; // otherwise change it back to sprite1
			audio.Stop();
			audio.clip = getMoney;
			audio.Play();
			timeToPeak = false;
		}
	}
}
