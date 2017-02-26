using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegionSelect : MonoBehaviour {

	public GameObject countryInfo;
	public GameObject countryUnlock;
	public GameObject insufficientFunds;
	public GameObject factoryUpgrade;
	public GameObject max;

	public Text regionSelectText;
	public Text factorySelectText;

	public Text fCost;
	public Text hCost;
	public Text mdCost;

	void FixedUpdate(){
		if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 10000.0f))
			{
				if (hit.collider.tag == ("country")) {
					if (CountryController.selectedCountry != null) 
					{
						CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
						c.SetOutlineCol (new Vector4 (0, 0, 0, 0));
					}
					//CountryController.selectedCountry.GetComponent<CountryController> ().SetOutlineCol (new Vector4 (0,0,0,0));
					CountryController.selectedCountry = hit.collider.gameObject; 
					CountryController cc = CountryController.selectedCountry.GetComponent<CountryController> ();
					cc.SetOutlineCol (new Vector4 (107, 130, 103, 255));

					regionSelectText.text = "Initial Factory Price: $" + cc.FactoryCost + "\n\nInitial Factory limit: " + cc.FactoryLimit;
					countryUnlock.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "$" + cc.purchaseCost;

					if (!CountryController.selectedCountry.GetComponent<CountryController> ().isLocked) {
						
						countryInfo.SetActive (true);
						countryUnlock.SetActive (false);
						factoryUpgrade.SetActive (false);
						//Write costs
						fCost.text = "$" + cc.FactoryCost;
						hCost.text = "$" + cc.FactoryLimitUpgradeCost;
						mdCost.text = "$" + cc.ManagingDirectorCost;
					} else {
						countryInfo.SetActive (false);
						countryUnlock.SetActive (true);
						factoryUpgrade.SetActive (false);


					}
				} else {
					if (CountryController.selectedCountry != null) 
					{
						CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
						c.SetOutlineCol (new Vector4 (0, 0, 0, 0));
					}
					countryInfo.SetActive (false);
					countryUnlock.SetActive (false);
					factoryUpgrade.SetActive (false);

				}

				if (hit.collider.tag == ("Factory")) {
					countryInfo.SetActive (false);
					countryUnlock.SetActive (false);
					factoryUpgrade.SetActive (true);
					Factory.selectedFactory = hit.collider.gameObject.GetComponent<Factory> ();

					factorySelectText.text = "Factory Level: " + Factory.selectedFactory.factoryLevel;
					factoryUpgrade.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "$" + Factory.selectedFactory.upgradeCost;
				}

				if (hit.collider.tag == ("pickup"))
				{
					GameObject.Destroy (hit.collider.gameObject);
					money.moneyValue += hit.collider.gameObject.GetComponent<collectMoney> ().value;
				}
			}
		}
	}

	public void UnlockRegion()
	{
		CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
		if (money.moneyValue >= c.purchaseCost) {
			c.isLocked = false;
			money.moneyValue -= c.purchaseCost;
			countryUnlock.SetActive (false);
			countryInfo.SetActive (true);
		} else {
			insufficientFunds.SetActive (true);
		}
	}

	public void UpgradeFactoryLimit() 
	{
		CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
		if ((money.moneyValue >= c.FactoryLimitUpgradeCost) && (c.FactoryLimit < c.maxFactoryLimit)) {
			c.FactoryLimit++;
			money.moneyValue -= c.FactoryLimitUpgradeCost;
			countryInfo.SetActive (true);

			c.FactoryLimitUpgradeCost += (c.FactoryLimitUpgradeCost * c.FactoryLimitUpgradeCost) / 75000;
		}
		else if (c.FactoryLimit < c.maxFactoryLimit)
		{
			insufficientFunds.SetActive (true);
		}
		//Write costs
		fCost.text = "$" + c.FactoryCost;
		hCost.text = "$" + c.FactoryLimitUpgradeCost;
		mdCost.text = "$" + c.ManagingDirectorCost;
	}

	public void UpgradeSelectedFactory()
	{
		if(Factory.selectedFactory != null && money.moneyValue >= Factory.selectedFactory.upgradeCost)
		{
			money.moneyValue -= Factory.selectedFactory.upgradeCost;
			Factory.selectedFactory.factoryLevel++;
			Factory.selectedFactory.upgradeCost += Factory.selectedFactory.factoryLevel * (Factory.selectedFactory.factoryLevel) * 100; //Will need to balance
		}
		else if(money.moneyValue <= Factory.selectedFactory.upgradeCost)
		{
			insufficientFunds.SetActive (true);
		}

		factorySelectText.text = "Factory Level: " + Factory.selectedFactory.factoryLevel;
		factoryUpgrade.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "$" + Factory.selectedFactory.upgradeCost;
	}

	public void UpdateUI()
	{
		CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
		//Write costs
		fCost.text = "$" + c.FactoryCost;
		hCost.text = "$" + c.FactoryLimitUpgradeCost;
		mdCost.text = "$" + c.ManagingDirectorCost;
	}
}