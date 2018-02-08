using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {
	private BoxCollider2D bounds;

	// Use this for initialization
	void Start () {
		bounds = GetComponent<BoxCollider2D>();

	}

	public Vector3 GetMinBounds()
	{
		return bounds.bounds.min;
	}

	public Vector3 GetMaxBounds()
	{
		return bounds.bounds.max;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
