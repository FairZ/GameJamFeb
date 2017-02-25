using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountryController : MonoBehaviour {

	public int FactoryLimit;
	public int NoOfFactories;
	public int SanctionPercentage;
	public bool ManagingDirector;


	public static GameObject selectedCountry;
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

	void UpgradeFactoryLimitInCountry()
	{
		if (this.gameObject == selectedCountry)
		{
			this.FactoryLimit++;
			CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ());

		}
	}



}
