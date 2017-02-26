using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CountryController : MonoBehaviour {

	public int maxFactoryLimit;
	public int FactoryLimit;
	public int NoOfFactories;
	public int SanctionPercentage;
	public bool ManagingDirector;
	public int ManagingDirectorCost;
	public int FactoryCost; 
	public int FactoryUpgradecost; 
	public int purchaseCost;

	public float cMultiplyer = 1f;

	public static GameObject startingCountry;
	public static GameObject selectedCountry;

	public Text selectedCountryText;
	public Text CountryFactoryLimitText;
	private Button FactoryLimitUpgrade;

	public GameObject factoryPrefab;
	private List<GameObject> factoryList = new List<GameObject>();

	private Material matRef;

	public bool isAddingFactory = false;

	public bool isLocked = true;

	public GameObject insufficientFunds;

	void Start()
	{
		//will need changing to balance


		//Button FactoryLimitUpgrade = GameObject.Find ("upgradeButton").GetComponent<Button>();
		//FactoryLimitUpgrade.onClick.AddListener (UpgradeFactoryLimitInCountry);
		//CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ()); 

		matRef = this.gameObject.GetComponent<MeshRenderer>().material;
		SetOutlineCol (new Vector4 (0,0,0,0)); //Initialising as off
		Debug.Log (Shader.PropertyToID ("_OutlineColor"));

		insufficientFunds = GameObject.Find ("Insufficient Funds");
		//CountryFactoryLimitText.text = ("No. of Factories: " + NoOfFactories.ToString() + FactoryLimit.ToString ()); 

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
		if (selectedCountry != null) {
			if (selectedCountry.name == "africaPoly")
				selectedCountryText.text = ("Region: Africa");
			else if (selectedCountry.name == "asiaPoly")
				selectedCountryText.text = ("Region: Asia");
			else if (selectedCountry.name == "australiaPoly")
				selectedCountryText.text = ("Region: Australia");
			else if (selectedCountry.name == "europePoly")
				selectedCountryText.text = ("Region: Europe");
			else if (selectedCountry.name == "nAmericaPoly")
				selectedCountryText.text = ("Region: North America");
			else if (selectedCountry.name == "sAmericaPoly")
				selectedCountryText.text = ("Region: South America");
			else if (selectedCountry.name == "ukPoly")
				selectedCountryText.text = ("Region: United Kingdom");
		}
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
		if ((money.moneyValue >= selectedCountry.GetComponent<CountryController> ().FactoryCost) && (NoOfFactories < FactoryLimit)) {
			selectedCountry.GetComponent<CountryController> ().isAddingFactory = !isAddingFactory;
		} else if (NoOfFactories < FactoryLimit) {
			insufficientFunds.SetActive (true);
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
				NoOfFactories++;
				money.moneyValue -= selectedCountry.GetComponent<CountryController> ().FactoryCost;
			}
			else
			{
				GameObject.Destroy (fRef);
			}
		}

	}
	//Takes values between 0-255
	public void SetOutlineCol(Vector4 _col)
	{
		Vector4 c = _col.normalized;

		matRef.SetColor (Shader.PropertyToID("_OutlineColor"),new Color(c.x, c.y, c.z, c.w));
	}

}
