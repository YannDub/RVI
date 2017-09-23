using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationCible : MonoBehaviour {

	private Vector3 target;
	private Vector3 targetScreen;
	private Vector3 currentPositionMouse;
	private Vector3 initCamPos;
	private Ray targetRay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.currentPositionMouse = Input.mousePosition;

		if (Input.GetMouseButtonDown (0)) {
			this.targetScreen = Input.mousePosition;
			this.targetRay = Camera.main.ScreenPointToRay (this.targetScreen);
			RaycastHit hit;
			if (Physics.Raycast (this.targetRay, out hit)) {
				Vector3 hitPoint = this.targetRay.GetPoint (hit.distance - 1);

				this.initCamPos = this.transform.position;
				target = new Vector3 (hitPoint.x, this.transform.position.y, hitPoint.z);
			}
		}

		float angle = Input.GetAxis ("Mouse X");

		if (Input.GetMouseButton (0)) {
			float t = Mathf.Clamp (currentPositionMouse.y / targetScreen.y, 0f, 1f);
			Debug.Log (currentPositionMouse.y / targetScreen.y);
			this.transform.position = target * (1f - t) + this.initCamPos * t;
			Ray ray = Camera.main.ScreenPointToRay (currentPositionMouse);
			angle = Mathf.Atan2 (Vector3.Dot (Vector3.Cross (this.targetRay.direction, ray.direction), this.transform.up), Vector3.Dot (this.targetRay.direction, ray.direction)) * Mathf.Rad2Deg;
			angle = this.transform.rotation.y - angle;
		}

		this.transform.Rotate (angle * new Vector3 (0, 1, 0));
	}
}
