using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
	private CameraBounds camBounds;
	private float halfHeight;
	private float halfWidth;
	public static bool camExists = false;
	public GameObject followTarget;
	// Use this for initialization
	void Start()
	{
		tk2dCamera cam = GetComponent<tk2dCamera>();
		halfHeight = cam.CameraSettings.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
		if (!camExists)
		{
			camExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (followTarget == null)
		{
			if (!FindPlayer()) return;
		}

		Vector3 targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = targetPos;

		GetCamBounds();

		float clampedX = Mathf.Clamp(transform.position.x, camBounds.GetMinBounds().x + halfWidth, camBounds.GetMaxBounds().x - halfWidth);
		float clampedY = Mathf.Clamp(transform.position.y, camBounds.GetMinBounds().y + halfHeight, camBounds.GetMaxBounds().y - halfHeight);
		transform.position = new Vector3(clampedX, clampedY, transform.position.z);
	}

	public void UpdateCamera()
	{
		
	}

	public bool FindPlayer()
	{
		followTarget = GameObject.FindGameObjectWithTag("Player");
		if (followTarget == null)
		{
			return false;
		}
		else return true;
	}

	public void GetCamBounds()
	{
		camBounds = FindObjectOfType<CameraBounds>();
	}
}
