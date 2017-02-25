using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class money : MonoBehaviour {

	public static float moneyValue = 0.0f; 

	public Text moneyText;

	public void AddMoney(float _incr)
	{
		moneyValue += _incr;
	}

	void LateUpdate()
	{
		moneyText.text = moneyValue.ToString();
	}
}
