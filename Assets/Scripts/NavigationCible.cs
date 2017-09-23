using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationCible : MonoBehaviour {

	private Vector3 target;
	private Vector3 targetScreen;
	private Vector3 currentPositionMouse;
	private Vector3 initCamPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.currentPositionMouse = Input.mousePosition;

		if (Input.GetMouseButtonDown (0)) {
			this.targetScreen = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (this.targetScreen);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 hitPoint = ray.GetPoint (hit.distance - 1);

				this.initCamPos = this.transform.position;
				target = new Vector3 (hitPoint.x, this.transform.position.y, hitPoint.z);
			}
		}

		if (Input.GetMouseButton (0)) {
			float t = Mathf.Clamp (currentPositionMouse.y / targetScreen.y, 0f, 1f);
			Debug.Log (currentPositionMouse.y / targetScreen.y);
			this.transform.position = target * (1f - t) + this.initCamPos * t;
		}

		this.transform.Rotate (Input.GetAxis ("Mouse X") * new Vector3 (0, 1, 0));
	}
}
