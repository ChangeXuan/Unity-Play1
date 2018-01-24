using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircle : MonoBehaviour {
	//OnCollisionEnter2D
	private void OnTriggerEnter2D(Collider2D collision) {
		print ("collsion");
		if (collision.tag == "PinCircle") {
			GameObject.Find ("GameManager").GetComponent<GameManager> ().gameOver();
		}
	}
}
