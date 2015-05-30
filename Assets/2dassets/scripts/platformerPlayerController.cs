﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class platformerPlayerController : MonoBehaviour {
	
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool frozen = false;
	public int maxHealth = 3;
	public int health = 3;
	public float moveForce = 365f;
	public float bounceForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 100f;
	public Transform groundCheck;
	Vector3 startPoint;
	
	private Animator anim;
	private Rigidbody2D rb2d;

	public Text healthText;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		startPoint = this.transform.position;
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (Input.GetButtonDown("Jump"))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f);
			if(hit.collider != null) {
				Debug.Log ("jumping off " + hit.collider.name);
				jump = true;
			}
		}
	}
	
	void FixedUpdate()
	{
		if (!frozen) {
			float h = Input.GetAxis("Horizontal");
			
			anim.SetFloat("Speed", Mathf.Abs(h));

			if (Mathf.Abs(h) > 0) {

				if (h * rb2d.velocity.x < maxSpeed)
					rb2d.AddForce(Vector2.right * h * moveForce);
				
				if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
					rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
				
				if (h > 0 && !facingRight)
					Flip ();
				else if (h < 0 && facingRight)
					Flip ();
			}
			else if (!jump) {
				rb2d.velocity = new Vector2(0,rb2d.velocity.y);

			}
			
			if (jump)
			{
				Debug.Log ("jump");
				anim.SetTrigger("Jump");
				rb2d.AddForce(new Vector2(0f, jumpForce));
				jump = false;
			}
		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void LoseHealth()
	{
		health--;
		Debug.Log ("Healthtext " + healthText.GetComponent<Text>());
//		Debug.Log ("Healthtext2 " + healthText.GetComponent<Text>().text);
		healthText.GetComponent<Text>().text = "Health: " + health;
		if (health <= 0) {
			Debug.Log ("Gameover");
			Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
			StartCoroutine(WaitAndRestart());         
			
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Deadly")) {
			Debug.Log ("Deadly!");

			Vector2 diff = (transform.position - col.gameObject.transform.position).normalized * bounceForce;
			rb2d.AddForce(new Vector2(diff.x, diff.y) , ForceMode2D.Impulse);

			LoseHealth();
		}
	}

	IEnumerator WaitAndRestart()
	{
		Hide ();
		Freeze();
		yield return new WaitForSeconds(1);
		Application.LoadLevel(Application.loadedLevel);
	}

	void ResetPosition() {
		this.transform.position = startPoint;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().angularVelocity = 0f;
		jump = false;
	}

	void Show() {
		GetComponent<Renderer>().enabled = true;
	}

	void Hide() {
		GetComponent<Renderer>().enabled = false;
	}

	void Freeze() {
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().angularVelocity = 0f;
		frozen = true;
	}

	void UnFreeze() {
		frozen = false;
	}
}