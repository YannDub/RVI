using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject target;
	public float rotationSpeed = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (target.transform.position);
		this.transform.RotateAround (target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
