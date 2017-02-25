using UnityEngine;
using System.Collections;

public class MoonRotate : MonoBehaviour {

	public GameObject World;

	void Update () {
		transform.RotateAround (World.transform.position, Vector3.up, 20 * Time.deltaTime);
	}

}
