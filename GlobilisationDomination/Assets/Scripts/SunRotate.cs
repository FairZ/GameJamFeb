using UnityEngine;
using System.Collections;

public class SunRotate : MonoBehaviour {

	public GameObject World;

	void Update () {
		transform.RotateAround (World.transform.position, Vector3.up, 10 * Time.deltaTime);
	}
}
