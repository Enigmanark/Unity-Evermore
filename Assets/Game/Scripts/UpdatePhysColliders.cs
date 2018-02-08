using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePhysColliders : MonoBehaviour {
    private Rigidbody2D rgb;
    private bool moved = false;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!moved)
        {
            rgb.velocity = new Vector2(transform.position.x + 0.01f, transform.position.y);
            moved = true;
        } else
        {
            rgb.velocity = new Vector2(transform.position.x - 0.01f, transform.position.y);
            moved = false;
        }
	}
}
