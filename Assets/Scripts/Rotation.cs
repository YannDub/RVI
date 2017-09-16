using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public float rotationSpeed = 60.0f;

	// Use this for initialization
	void Start () {
		Debug.Log ("Name of object : " + this.name);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime,0));
	}
}
