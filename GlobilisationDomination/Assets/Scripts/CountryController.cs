using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountryController : MonoBehaviour {

	public int FactoryLimit;
	public int NoOfFactories;
	public int SanctionPercentage;
	public bool ManagingDirector;


	private GameObject selectedCountry;
	public Text selectedCountryText;
	public Text CountryFactoryLimitText;
	private Button FactoryLimitUpgrade;

	void Start()
	{
		//will need changing to balance
		FactoryLimit = 1;

		Button FactoryLimitUpgrade = GameObject.Find ("upgradeButton").GetComponent<Button>();
		FactoryLimitUpgrade.onClick.AddListener (UpgradeFactoryLimitInCountry);
		CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ());
	}

	void FixedUpdate(){
		



		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 10000.0f))
			{
				if (hit.collider.tag == ("country"))
				{
					selectedCountry = hit.collider.gameObject; 
					selectedCountryText.text = ("Selected Country: " + selectedCountry.name.ToString());
					//Debug.Log (selectedCountry.name);
				}
			}
		}

	}

	void UpgradeFactoryLimitInCountry()
	{
		if (this.gameObject == selectedCountry)
		{
			this.FactoryLimit++;

			CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ());
		}
	}



}
