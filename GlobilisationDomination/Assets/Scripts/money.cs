using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class money : MonoBehaviour {

	public static int moneyValue; 

	Text moneyText;

	void Update (){
		moneyText = GetComponent<Text> (); 

		moneyText = moneyValue.ToString();

	}
}
