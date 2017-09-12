using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraDualPoint : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEditor.Selection.gameObjects [0] != null && UnityEditor.Selection.gameObjects [0] != this)
			target = UnityEditor.Selection.gameObjects [0].transform;

		this.transform.LookAt (target);
	}
}
