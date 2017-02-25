using UnityEngine;
using System.Collections;

public class InsufficientFundsControl : MonoBehaviour {

	private float timer;
	private float timerMax = 1.0f;

	void OnEnable()
	{
		timer = timerMax;
	}

	void Start()
	{
		timer = 0;
	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			this.gameObject.SetActive (false);
		}
	}
}
