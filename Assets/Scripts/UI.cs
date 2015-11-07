using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

	private Text timer;
	private Text roundsPlayerOne;
	private Text roundsPlayerTwo;

	void Start() {
		timer = this.GetComponentInChildren<Text>();
		roundsPlayerOne = GameObject.FindGameObjectWithTag("RoundOne").GetComponent<Text> ();
		roundsPlayerTwo = GameObject.FindGameObjectWithTag("RoundTwo").GetComponent<Text> ();
	}

	public void IncreaseRounds (Player playerOne, Player playerTwo) {
		roundsPlayerOne.text = "" + playerOne.rounds;
		roundsPlayerTwo.text = "" + playerTwo.rounds;
	}

	public void SetTimerText (float time) {
		float tempTime = Mathf.Round (time);
		timer.text = tempTime.ToString ();
	}

}
