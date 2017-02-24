using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class money : MonoBehaviour {

	public static int moneyValue; 

	public Text moneyText;


	void Update (){
		moneyValue = 100;
		moneyText.text = moneyValue.ToString();

	}
}
