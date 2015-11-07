using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GlobalEventHandler eventHandler;

	private Animator animator;

	public float health;

	// Use this for initialization
	void Start () {
		this.health = 100;
		this.eventHandler = GetComponent<GlobalEventHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
			Death ();
	}

	void OnTriggerEnter (Collider enemy) {
		Debug.Log ("trigger entered");
		eventHandler.HandleClash ();
	}

	private void Death () {
		eventHandler.PlayerDeath (this.gameObject);
	}
}
