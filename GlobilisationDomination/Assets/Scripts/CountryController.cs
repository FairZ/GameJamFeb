using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountryController : MonoBehaviour {

	public int TotalWorkforce;
	public int UsedWorkforce;
	public int AvailableWorkForce;
	public int HousingLevel;
	public int NoOfFactories;
	public int FactoryLevel; 
	public int SanctionPercentage;
	public bool ManagingDirector;


	private GameObject selectedCountry;
	public Text selectedCountryText; 
	private Button upgradeButton;

	void Start()
	{
		FactoryLevel = 1;
		Button upgradeButton = GameObject.Find ("upgradeButton").GetComponent<Button>();
		upgradeButton.onClick.AddListener (UpgradeFactoriesInCountry);
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
					selectedCountryText.text = selectedCountry.name.ToString();
					//Debug.Log (selectedCountry.name);
				}
			}
		}

	}

	void UpgradeFactoriesInCountry()
	{
		if (this.gameObject == selectedCountry)
		{
			this.FactoryLevel++;
		}
	}



}
