using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private Transform startPoint;
	private Transform spawPoint;
	private Pin currentPin;
	private bool isGameOver = false;
	private int score = 0;
	private Camera mainCamera;
	private float speed = 3;

	public Text showScore;
	public GameObject pinPrefab;
	// Use this for initialization
	void Start () {
		startPoint = GameObject.Find ("StartPoint").transform;
		spawPoint = GameObject.Find ("SpawPoint").transform;
		this.spawPin ();
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			return;
		}
		if (Input.GetMouseButtonDown (0)) {
			score++;
			showScore.text = score.ToString ();
			currentPin.startFly ();
			this.spawPin ();
		}	
	}

	void spawPin() {
		currentPin = GameObject.Instantiate (pinPrefab, spawPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
	}

	public void gameOver() {
		if (isGameOver) {
			return;
		}
		GameObject.Find ("Circle").GetComponent<RotateSelf> ().enabled = false;
		StartCoroutine (gameOverAnimation());
		isGameOver = true;
	}

	IEnumerator gameOverAnimation() {
		while (true) {
			mainCamera.backgroundColor = Color.Lerp (mainCamera.backgroundColor, Color.red, Time.deltaTime * speed);
			mainCamera.orthographicSize = Mathf.Lerp (mainCamera.orthographicSize, 4, Time.deltaTime * speed);
			if (Mathf.Abs (mainCamera.orthographicSize - 4) < 0.01f) {
				break;
			}
			yield return 0;
		}
		yield return new WaitForSeconds (0.25f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
