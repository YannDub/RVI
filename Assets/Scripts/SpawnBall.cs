using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

	private Plane plane;
	public Object obj;

	// Use this for initialization
	void Start () {
		plane = new Plane (new Vector3(1.0f,0f,0.0f), new Vector3(1.0f, 10f, -10f));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (plane.Raycast (ray, out rayDistance)) {
				Object.Instantiate (obj, ray.GetPoint(rayDistance), new Quaternion());
			}
		}
	}
}
