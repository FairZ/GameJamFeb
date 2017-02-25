using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

	private Vector3 PreviousMousePos;
	private Vector3 MouseMovement;
	private Vector3 PreviousPos;
	private Vector3 PreviousRot;

	public GameObject World;

	void Update () {
		if (Input.GetMouseButtonDown (0) && Input.GetKey(KeyCode.LeftControl)) {
			PreviousMousePos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0) && Input.GetKey(KeyCode.LeftControl)) {
			MouseMovement = PreviousMousePos - Input.mousePosition;
			World.transform.Rotate (0, MouseMovement.x/10, 0);
			PreviousPos = transform.position;
			PreviousRot = transform.eulerAngles;
			transform.RotateAround (Vector3.zero, Vector3.right, MouseMovement.y/10);
			if ((transform.eulerAngles.x > 45)&&(transform.eulerAngles.x < 315)) {
				transform.position = PreviousPos;
				transform.eulerAngles = PreviousRot;
			}
			PreviousMousePos = Input.mousePosition;
		}
	}
}
