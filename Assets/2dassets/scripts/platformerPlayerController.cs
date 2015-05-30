using UnityEngine;
using System.Collections;

public class platformerPlayerController : MonoBehaviour {
	
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool frozen = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 100f;
	public Transform groundCheck;
	Vector3 startPoint;
	
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	public GameObject explosionPrefab;
	
	
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		startPoint = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log ("jump press");
			float distanceAboveGround = 5.0f; // When the player is 5 units vertically above ground, hit.collider != null.
			RaycastHit2D hit;
			LayerMask layermask = 1 << LayerMask.NameToLayer("Ground"); // Add a layer mask via inspector if you want
			hit = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f);
			Debug.DrawLine(groundCheck.position, new Vector3(0, 0, -20.1f), Color.white);
			if(hit.collider != null) {
				Debug.Log ("what the " + hit.collider.name);
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

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Deadly")) {
			Debug.Log ("Deadly!");
			Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
			StartCoroutine(WaitAndRestart());         
		}
	}

	IEnumerator WaitAndRestart()
	{
		Hide ();
		Freeze();
		yield return new WaitForSeconds(1);
		ResetPosition();
		Show ();
		UnFreeze();
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