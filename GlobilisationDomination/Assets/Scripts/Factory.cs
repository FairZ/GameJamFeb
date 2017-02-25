using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

	private float baseVal = 100.0f; //Will need balancing

	private float expEpsilon = 0.01f;
	public int factoryLevel = 1;

	private const float TIMER_MAX = 2.0f; //Will need balancing
	private float moneyTimer = TIMER_MAX;

	public GameObject moneyballPreFab;
	private GameObject moneyball;

	void Start()
	{
		//Get moneyballPreFab
	}

	public void UpdateFactory(float _cMult, bool _isManaged)
	{
		if (moneyball = null) {
			moneyTimer -= Time.deltaTime;
			if (moneyTimer <= 0.0f) {
				float moneyVal = 0.0f;

				moneyVal = baseVal * _cMult * (Mathf.Pow (expEpsilon, factoryLevel / 10.0f)); //Will need balancing

				if (_isManaged) {
					//Add money directly to player
					money.moneyValue += moneyVal;
				} else {
					//Release moneyball with moneyVal
					moneyball = (GameObject)Instantiate (moneyballPreFab, transform.position, transform.rotation);
					moneyball.GetComponent<collectMoney> ().value = (int)moneyVal;
				}
			}
		} else {
			moneyTimer = TIMER_MAX;
		}

	}

	public void UpgradeLevel()
	{
		factoryLevel++;
	}

}
