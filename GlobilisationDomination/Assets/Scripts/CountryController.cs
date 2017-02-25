using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CountryController : MonoBehaviour {

	public int FactoryLimit;
	public int NoOfFactories;
	public int SanctionPercentage;
	public bool ManagingDirector;
	public int FactoryCost; 
	public int FactoryUpgradecost; 

	public float cMultiplyer = 1f;

	public static GameObject startingCountry;
	public static GameObject selectedCountry;

	public Text selectedCountryText;
	public Text CountryFactoryLimitText;
	private Button FactoryLimitUpgrade;

	public GameObject factoryPrefab;
	private List<GameObject> factoryList = new List<GameObject>();

	public bool isAddingFactory = false;

	public bool isLocked = true;

	void Start()
	{
		//will need changing to balance
		FactoryLimit = 1;

		Button FactoryLimitUpgrade = GameObject.Find ("upgradeButton").GetComponent<Button>();
		FactoryLimitUpgrade.onClick.AddListener (UpgradeFactoryLimitInCountry);
		CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ()); 
	}

	void Update()
	{
		foreach (GameObject f in factoryList)
		{
			f.GetComponent<Factory> ().UpdateFactory (cMultiplyer, ManagingDirector);
		}

		RegionNameText ();
		//selectedCountryText.text = ("Region: " + selectedCountry.name.ToString ());

	}

	void RegionNameText()
	{
		/*
		if (selectedCountry.name == "africaPoly")
			selectedCountryText.text = ("Region: Africa");
		else if (selectedCountry.name == "asiaPoly")
			selectedCountryText.text = ("Region: Asia");
		else if (selectedCountry.name == "australiaPoly")
			selectedCountryText = ("Region: Australia");
		*/
	}

	void FixedUpdate()
	{
		if(isAddingFactory)
		{
			if(Input.GetMouseButton(1))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if(Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject == selectedCountry)
						AddFactory (hit.point);
				}

			}
			else if(Input.GetMouseButton(0))
			{
				isAddingFactory = false;
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

	public void SwitchAddingState()
	{
		if (money.moneyValue >= selectedCountry.GetComponent<CountryController> ().FactoryCost) 
		{
			selectedCountry.GetComponent<CountryController> ().isAddingFactory = !isAddingFactory;
		}
	}

	void AddFactory(Vector3 _loc)
	{
		GameObject pRef = GameObject.Find ("globe");
		Vector3 dir = (pRef.transform.position + _loc).normalized;
		GameObject fRef = Instantiate (factoryPrefab, _loc + (dir * 10.0f), new Quaternion ()) as GameObject;

		fRef.transform.localScale *= 0.25f;
		fRef.transform.up = dir;

		RaycastHit hit;
		if(fRef.GetComponent<Rigidbody>().SweepTest(-dir, out hit))
		{
			if(hit.collider.gameObject == selectedCountry)
			{
				fRef.transform.position = hit.point;

				fRef.transform.parent = selectedCountry.transform;
				SwitchAddingState ();

				factoryList.Add (fRef);

				money.moneyValue -= selectedCountry.GetComponent<CountryController> ().FactoryCost;
			}
			else
			{
				GameObject.Destroy (fRef);
			}
		}

	}


}
