using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private bool isFly = false;
	private bool isReach = false;
	private Transform startPoint;
	private Transform cricle;
	private Vector3 targetPoint;

	private float speed = 25;
	// Use this for initialization
	void Start () {
		startPoint = GameObject.Find ("StartPoint").transform;
		cricle = GameObject.Find ("Circle").transform;
		//cricle = GameObject.FindGameObjectWithTag("Circle").transform;
		targetPoint = cricle.position;
		targetPoint.y -= cricle.transform.localScale.y*2;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFly) {
			if (!isReach) {
				transform.position = Vector3.MoveTowards (transform.position, startPoint.position, Time.deltaTime * speed);
				if (Vector3.Distance (transform.position, startPoint.position) < 0.05f) {
					isReach = true;
				}
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, targetPoint, Time.deltaTime * speed);
			if (Vector3.Distance (transform.position, targetPoint) < 0.05f) {
				transform.position = targetPoint;
				transform.parent = cricle;
				isFly = false;
			}
		}
	}

	public void startFly() {
		isFly = true;
		isReach = true;
	}
}
