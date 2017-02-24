using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

	private Vector3 PreviousMousePos;
	private Vector3 MouseMovement;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			PreviousMousePos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			MouseMovement = PreviousMousePos - Input.mousePosition;
			transform.Rotate (-MouseMovement.y/10,MouseMovement.x/10, 0, Space.World);
			PreviousMousePos = Input.mousePosition;
		}
	}
}
