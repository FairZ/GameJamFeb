using UnityEngine;
using System.Collections;

public class collectMoney : MonoBehaviour {

	public float factoryLevelMultiplier = 1;
	CountryController countryController; 


	void Start(){
		
		countryController = transform.parent.parent.gameObject.GetComponent<CountryController>();
		//Debug.Log (countryController.FactoryLevel);


	}




}
