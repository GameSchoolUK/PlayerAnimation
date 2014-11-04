using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {

	public float moveSpeed = 10;

	public float jumpHeight = 500;
	public float multiplier;
	public Animator animator;
	bool grounded = true;

	//Count for coin points
	private int count = 0;

	//GuiText object
	public GUIText scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + count.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		//animator.SetBool("Walking", false);
		//Move the player to the left
		animator.SetInteger("Speed", 0 );
		if(Input.GetKey(KeyCode.A)){
			//vector 3 X , Y , Z
			//Multiplying by deltaTime will mean the movespeed modifier applies every second rather than every frame
			transform.Translate(new Vector3(-moveSpeed,0,0) * Time.deltaTime );
			animator.SetInteger("Speed", 20 );
		}
		if (Input.GetKeyDown(KeyCode.A)){
			transform.localScale = new Vector3(-2, 2, 2);
		}
		//Move the player to the right
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(new Vector3(moveSpeed,0,0)* Time.deltaTime);
			animator.SetInteger("Speed", 20 );
		}
		if (Input.GetKeyDown(KeyCode.D)){
			transform.localScale = new Vector3(2, 2, 2);
		}

		//Jump handler

		/*if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody2D.AddForce(Vector2.up * jumpHeight);
		}*/

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (grounded) {
				rigidbody2D.AddForce(Vector2.up * jumpHeight);
				grounded = false;
			}
		}
}

	//Trigger handler
	//coin handler
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Coin"){
			other.gameObject.SetActive(false);
			//add to score
			count = count + 1;
			scoreText.text = "Score: " + count.ToString();
		}
	}
	void OnCollisionEnter2D (Collision2D hit)
	{
		grounded = true;
		// check message upon collition for functionality working of code.
		Debug.Log ("I am colliding with something");
	}
}
