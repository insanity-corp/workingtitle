using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public void DecreaseHealth (string player) {
		if (player.Equals ("both")) {
			Debug.Log ("both decreased");
		} else if (player.Equals ("playerOne")) {
			Debug.Log ("playerOne decreased");
		} else {
			Debug.Log ("playerTwo decreased");
		}
	}

}
