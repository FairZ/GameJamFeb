using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
		regionInformation.text = ("\tNorth america\n\n Start with a small loan of a million dollars\n\n Shame about the wall though, South America is gonna be expensive");

	}

	public void SouthAmerica()
	{
		currentSelection = 2;
		regionInformation.text = ("\tSouth America\n\n Start with less money\n\n At least you managed to get that tunnel under the wall built");

	}

	public void UnitedKingdom()
	{
		currentSelection = 3;
		regionInformation.text = ("\tUnited Kingdom\n\n Start with a decent amount\n\n Europe is more expensive; you know what you did.");

	}

	public void Europe()
	{
		currentSelection = 4;
		regionInformation.text = ("\tEurope\n\n Start with a fair amount\n\n Lots of room for factories though"); //Is this right!?

	}

	public void Asia()
	{
		currentSelection = 5;
		regionInformation.text = ("\tAsia\n\n Small amount to start with\n\n Super cheap to make room for factories though");

	}

	public void Australia()
	{
		currentSelection = 6;
		regionInformation.text = ("\tAustralia\n\n Starts with a decent amount\n\n More expensive to move between regions");

	}

	public void Africa()
	{
		currentSelection = 7;
		regionInformation.text = ("\tAfrica\n\n Start with a small amount\n\n Cheap to build factories, but produce less");

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
				//more expensive to go to other countries
				//35 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 400000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 750000;

				break;
			case 2:
				GameObject.Find("sAmericaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 300000;
				//make north america less expensive
				//higher natural factory limit
				//45 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 400000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 700000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 750000;
				break;
			case 3:
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().isLocked = false; 
				money.moneyValue = 750000;
				//make eu more expensive
				//slightly more expensive to move to other countries
				//5 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 800000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 1000000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				break;
			case 4:
				GameObject.Find("europePoly").GetComponent<CountryController>().isLocked = false;
				money.moneyValue = 400000;
				//30 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 900000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 1000000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				break;
			case 5:
				GameObject.Find("asiaPoly").GetComponent<CountryController>().isLocked = false;
				money.moneyValue = 200000;
				//highest natural factory limit
				//110 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 400000;
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 750000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 1000000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				break;
			case 6: 
				GameObject.Find("australiaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 600000;
				//little less expensive than uk to move to other countries
				//20 max limit for factories
				GameObject.Find ("africaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 500000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 850000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 1100000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 400000;
				break;
			case 7:
				GameObject.Find("africaPoly").GetComponent<CountryController>().isLocked = false; 
				money.moneyValue = 200000;
				//cheaper upgrade cost
				//75 max limit for factories
				GameObject.Find ("australiaPoly").GetComponent<CountryController> ().purchaseCost = 600000;
				GameObject.Find ("europePoly").GetComponent<CountryController> ().purchaseCost = 400000;
				GameObject.Find ("asiaPoly").GetComponent<CountryController> ().purchaseCost = 200000;
				GameObject.Find ("ukPoly").GetComponent<CountryController> ().purchaseCost = 750000;
				GameObject.Find ("nAmericaPoly").GetComponent<CountryController> ().purchaseCost = 1000000;
				GameObject.Find ("sAmericaPoly").GetComponent<CountryController> ().purchaseCost = 300000;
				break; 
			default:
				Debug.Log ("You done fucked up");
				break; 
			}

		}
	}


}
