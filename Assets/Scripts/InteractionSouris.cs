using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSouris : MonoBehaviour {
	private GameObject text;
	private GameObject objCollider = null;
	private Plane plane;

	public float speed = 10f;
	public bool screen_space = false;

	// Use this for initialization
	void Start () {
		text = new GameObject ();
		text.AddComponent<GUIText> ();
		this.plane = new Plane ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit) && this.objCollider == null) {
				this.objCollider = hit.collider.gameObject;
			} 

			if (!screen_space) {
				// x,z game object move
				this.objCollider.gameObject.transform.Translate (new Vector3 (Input.GetAxis ("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxis ("Mouse Y") * Time.deltaTime * speed), Space.World);
				Debug.Log (Input.GetAxis ("Mouse X") * Time.deltaTime);
			} else {
				float distance = 0;
				this.plane = new Plane (-Camera.main.transform.forward, this.objCollider.transform.position);
				if (this.plane.Raycast (ray, out distance)) {
					Vector3 projection = ray.GetPoint (distance);
					Debug.Log (projection);
					this.objCollider.transform.position = projection;
				}
			}
		} else {
			this.objCollider = null;
		}

		if (this.objCollider != null) {
			text.GetComponent<GUIText> ().text = this.objCollider.name + "\n" + this.objCollider.transform.position;
			text.GetComponent<GUIText> ().pixelOffset = new Vector2 (Screen.width / 2, Screen.height / 2);
		}
	}
}
