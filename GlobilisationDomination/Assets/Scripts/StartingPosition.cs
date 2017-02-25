using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartingPosition : MonoBehaviour {

	private int currentSelection;
	public Transform startingPositionPanel;

	public Text regionInformation; 



	void Start()
	{
		currentSelection = 0;
		regionInformation.text = ("Click on a country to display information");
	}
		
	public void NorthAmerica()
	{
		currentSelection = 1;
		regionInformation.text = ("North america info");

	}

	public void SouthAmerica()
	{
		currentSelection = 2;
		regionInformation.text = ("South america info");

	}

	public void UnitedKingdom()
	{
		currentSelection = 3;
		regionInformation.text = ("uk info");

	}

	public void Europe()
	{
		currentSelection = 4;
		regionInformation.text = ("europe info");

	}

	public void Asia()
	{
		currentSelection = 5;
		regionInformation.text = ("asia info");

	}

	public void Australia()
	{
		currentSelection = 6;
		regionInformation.text = ("australia info");

	}

	public void Africa()
	{
		currentSelection = 7;
		regionInformation.text = ("africa info");

	}

	public void ConfirmSelection()
	{
		if (currentSelection != 0)
		{
			startingPositionPanel.gameObject.SetActive (false);


			switch (currentSelection)
			{
			case 1:
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().isLocked = false; 
				money.moneyValue = 1000000;
				//make south america more expensive
				break;
			case 2:
				GameObject.Find("sAmericaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 0;
				//make north america more/less expensive
				break;
			case 3:
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().isLocked = false; 
				money.moneyValue = 0;
				//make eu more expensive
				break;
			case 4:
				GameObject.Find("europePoly").GetComponent<CountryController>().isLocked = false;
				money.moneyValue = 0;
				break;
			case 5:
				GameObject.Find("asiaPoly").GetComponent<CountryController>().isLocked = false;
				money.moneyValue = 0;
				break;
			case 6: 
				GameObject.Find("australiaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 0;
				break;
			case 7:
				GameObject.Find("africaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 0;
				break; 
			default:
				break; 
			}

		}
	}


}
