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

	public static GameObject startingCountry;
	public static GameObject selectedCountry;

	public Text selectedCountryText;
	public Text CountryFactoryLimitText;
	private Button FactoryLimitUpgrade;

	public GameObject factoryPrefab;
	private List<GameObject> factoryList;

	public bool isAddingFactory = false;

	void Start()
	{
		//will need changing to balance
		FactoryLimit = 1;

		Button FactoryLimitUpgrade = GameObject.Find ("upgradeButton").GetComponent<Button>();
		FactoryLimitUpgrade.onClick.AddListener (UpgradeFactoryLimitInCountry);
		CountryFactoryLimitText.text = ("Factory Limit: " + FactoryLimit.ToString ());
	}

	void FixedUpdate()
	{
		if(isAddingFactory)
		{
			if(Input.GetMouseButton(0))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if(Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject == selectedCountry)
						AddFactory (hit.point);
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

	public void SwitchAddingState()
	{
		isAddingFactory = !isAddingFactory;
	}

	void AddFactory(Vector3 _loc)
	{
		GameObject pRef = GameObject.Find ("globe");

		Vector3 dir = (pRef.transform.position + _loc).normalized;

		GameObject fRef = Instantiate (factoryPrefab, _loc + (dir * 10.0f), new Quaternion ()) as GameObject;

		RaycastHit hit;
		if(fRef.GetComponent<Rigidbody>().SweepTest(-dir, out hit))
		{
			if(hit.collider.gameObject == selectedCountry)
			{
				fRef.transform.position = hit.point;
				fRef.transform.up = dir;
				SwitchAddingState ();
			}
		}


	}


}
