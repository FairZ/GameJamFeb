using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

	public static Factory selectedFactory;

	private float baseVal = 100.0f; //Will need balancing

	public float expEpsilon = 0.01f;
	public int factoryLevel = 1;

	public float upgradeCost = 1000;

	private const float TIMER_MAX = 20.0f; //Will need balancing
	private float moneyTimer = TIMER_MAX;

	public GameObject moneyballPreFab; 
	private GameObject moneyball;

	public AudioClip placedSound;
	public AudioClip moneybagSound;

	void Start()
	{
		AudioSource aRef = this.GetComponent<AudioSource> ();
		//aRef.clip = SoundController.factoryPlace;
		aRef.pitch += Random.Range (-0.15f, 0.15f);
		aRef.PlayOneShot (placedSound);
	}

	public void UpdateFactory(float _cMult, bool _isManaged)
	{
		moneyTimer -= Time.deltaTime;
		if (moneyTimer <= 0.0f) {
			float moneyVal = 0.0f;

			moneyVal = baseVal * _cMult * (Mathf.Pow (expEpsilon, factoryLevel / 10.0f)); //Will need balancing

			if (_isManaged) {
				//Add money directly to player
				money.moneyValue += (int)moneyVal;
			} else {
				//Release moneyball with moneyVal
				moneyball = (GameObject)Instantiate (moneyballPreFab, transform.position, transform.rotation);

				moneyball.transform.localScale *= 0.1f;
				moneyball.transform.parent = this.transform.parent;
				moneyball.transform.up = this.transform.up;

				moneyball.GetComponent<collectMoney> ().parentFactory = this.gameObject;

				moneyball.GetComponent<collectMoney> ().value = (int)moneyVal;

				AudioSource aRef = moneyball.GetComponent<AudioSource> ();
				//aRef.clip = SoundController.moneyBagAppear;
				aRef.pitch += Random.Range (-0.15f, 0.15f);
				aRef.PlayOneShot (moneybagSound);

				if (aRef.isPlaying)
					Debug.Log ("Sound");
			}
			moneyTimer = TIMER_MAX;
		}

	}

	public void UpgradeLevel()
	{
		factoryLevel++;
	}


}
