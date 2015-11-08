using UnityEngine;
using System.Collections;

public class GlobalEventHandler : MonoBehaviour {

	[SerializeField]
	private int speed;
	[SerializeField]
	private GameObject playerOne;
	[SerializeField]
	private GameObject playerTwo;
	[SerializeField]
	private float time;

	private Player playerOneScript;
	private Player playerTwoScript;
	private UI UIScript;

	private int stage;
	private bool timing;

	private float startPositionLeft;
	private float startPositionRight;

	void Start () {
		playerOneScript = playerOne.GetComponent<Player> ();
		playerTwoScript = playerTwo.GetComponent<Player> ();
		UIScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UI> ();

		startPositionLeft = -24;
		startPositionRight = 24;
	}

	void Update () {
		if (timing) {
			UIScript.SetTimerText (time);
			if (time <= 0)
				HandleTimeout ();
			time -= Time.deltaTime;
		}
	}

	void FixedUpdate () {
	
	}

	public void PlayerDeath (GameObject player) {
		
	}

	private void StartStage () {
		timing = true;
		SetTransformX (playerOne);
		SetTransformX (playerTwo);
	}
	
	public void HandleClash () {
		Animator playerOneAnimator = playerOne.GetComponent<Animator> ();
		Animator playerTwoAnimator = playerOne.GetComponent<Animator> ();

		if (animationPlaybackTime (playerOneAnimator) > animationPlaybackTime (playerTwoAnimator)) {
			playerOneScript.rounds++;
		} else {
			playerTwoScript.rounds++;
		}

		UIScript.IncreaseRounds (playerOneScript, playerTwoScript);
		stage -= 1;

		StartStage ();
	}

	private void HandleTimeout () {
		timing = false;
	}

	public float animationPlaybackTime (Animator animator) {
		AnimatorStateInfo animatorCurrentState = animator.GetCurrentAnimatorStateInfo (0);
		return animatorCurrentState.normalizedTime % 1;
	}

	private void SetTransformX (GameObject player) {
		Transform playerTransform = player.transform;
		Vector3 position = playerTransform.position;

		Movement movementScript = player.GetComponent<Movement> ();

		if (movementScript.left) {
			startPositionLeft += 4;
			position.x = startPositionLeft;
		} else {
			startPositionRight -= 4;
			position.x = startPositionRight;
		}

		player.transform.position = position;
	}
}
