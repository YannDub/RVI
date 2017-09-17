using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationFPS : MonoBehaviour {
	public float moveSpeed = 60;
	public float rotationSpeed = 60;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rotationX += Input.GetAxis ("Mouse X") * rotationSpeed * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * rotationSpeed * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

		this.transform.Translate (Input.GetAxis("Horizontal") * moveSpeed * Vector3.right * Time.deltaTime);

		float moveDirection = Input.GetAxis ("Vertical");
		if (moveDirection != 0) {
			Quaternion rot = transform.rotation;
			Vector3 position = this.transform.position;
			Vector3 direction = rot * Vector3.forward;
			position.x += direction.x * Time.deltaTime * moveSpeed * moveDirection;
			position.z += direction.z * Time.deltaTime * moveSpeed * moveDirection;
			this.transform.position = position;
		}
	}
}
