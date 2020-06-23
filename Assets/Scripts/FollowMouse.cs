using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class FollowMouse : MonoBehaviour {
 
	private Vector3 mousePosition;
	public float speed;
	private Vector3 lastMousePos;
	private Quaternion lastRotation;

	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		transform.position = new Vector3 (mousePosition.x, mousePosition.y, 0);
		// Rotate Towards Direction
		Vector3 dir = Input.mousePosition - Vector3.zero;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

		float mouseDir = transform.position.y - lastMousePos.y;
		
		if (mouseDir > 0.05)
		{
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		}
		if (mouseDir <= -0.05)
		{
			transform.rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
		}

		lastMousePos = transform.position;

	}
}
