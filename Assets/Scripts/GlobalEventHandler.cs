using UnityEngine;
using System.Collections;

public class GlobalEventHandler : MonoBehaviour {

	[SerializeField]
	private int speed;
	[SerializeField]
	private GameObject playerOne;
	[SerializeField]
	private GameObject playerTwo;

	private Player playerOneScript;
	private Player playerTwoScript;
	private UI UIScript;

	private int stage;

	void Start () {
		playerOneScript = playerOne.GetComponent<Player> ();
		playerTwoScript = playerTwo.GetComponent<Player> ();
		UIScript = GetComponent<UI> ();
	}
	
	void FixedUpdate () {
	
	}

	public void PlayerDeath (GameObject player) {
		
	}

	public void HandleClash () {
		Animator playerOneAnimator = playerOne.GetComponent<Animator> ();
		Animator playerTwoAnimator = playerOne.GetComponent<Animator> ();

		string player;

		if (animationPlaybackTime (playerOneAnimator) == animationPlaybackTime (playerTwoAnimator)) {
			playerOneScript.health -= 10;
			playerTwoScript.health -= 10;
			player = "both";
		} else if (animationPlaybackTime (playerOneAnimator) > animationPlaybackTime (playerTwoAnimator)) {
			playerOneScript.health -= 10;
			player = "playerOne";
		} else {
			playerTwoScript.health -= 10;
			player = "playerTwo";
		}

		UIScript.DecreaseHealth (player);
	}

	public float animationPlaybackTime (Animator animator) {
		AnimatorStateInfo animatorCurrentState = animator.GetCurrentAnimatorStateInfo (0);
		return animatorCurrentState.normalizedTime % 1;
	}
}
