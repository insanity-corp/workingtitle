using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField]
	private float Speed;
	[SerializeField]
	private bool left;
	[SerializeField]
	private KeyCode movementKey;
	[SerializeField]
	private KeyCode attackKey;

	private Rigidbody2D rigidbody;
	private Animator animator;

	private bool moving;
	private bool attacking;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		if (!left)
			Flip ();
	}

	void Update () {
		HandleInput ();
	}

	void FixedUpdate () {
		moving = Input.GetKey (movementKey);
		HandleMovement ();
		HandleAttack ();

		ResetFields ();
	}

	private void HandleInput() {
		attacking = Input.GetKey (attackKey);
	}

	private void HandleMovement () {
		int movement = moving ? 1 : 0;
		if (left)
			rigidbody.velocity = new Vector2(movement * Speed, rigidbody.velocity.y);
		else
			rigidbody.velocity = new Vector2(-1 * movement * Speed, rigidbody.velocity.y);

		animator.SetBool ("moving", moving);
	}

	private void HandleAttack () {
		if (attacking && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
			animator.SetTrigger ("attack");
	}

	private void Flip () {
		Vector3 playerScale = transform.localScale;

		playerScale.x *= -1;

		transform.localScale = playerScale;
	}

	private void ResetFields() {
		attacking = false;
	}
}
