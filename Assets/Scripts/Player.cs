using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GlobalEventHandler eventHandler;

	public float health;
	public int rounds;

	// Use this for initialization
	void Start () {
		this.rounds = 0;
		this.eventHandler = GameObject.FindGameObjectWithTag("EventHandler").GetComponent<GlobalEventHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rounds >= 5)
			Death ();
	}

	void OnTriggerEnter2D (Collider2D enemy) {
		if (enemy.gameObject.GetComponent<Player> () == null)
			return;
		Debug.Log ("trigger entered");
		eventHandler.HandleClash ();
	}

	private void Death () {
		eventHandler.PlayerDeath (this.gameObject);
	}
}
