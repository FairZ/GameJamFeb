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
				//CountryController.startingCountry = na;
				GameObject.Find("nAmericaPoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 2:
				//CountryController.startingCountry = southamerica;
				GameObject.Find("sAmericaPoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 3:
				//CountryController.startingCountry = uk;
				GameObject.Find("ukPoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 4:
				//CountryController.startingCountry = eu;
				GameObject.Find("europePoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 5:
				//CountryController.startingCountry = asia;
				GameObject.Find("asiaPoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 6: 
				//CountryController.startingCountry = australia;
				GameObject.Find("australiaPoly").GetComponent<CountryController>().isLocked = false; 
				break;
			case 7:
				//CountryController.startingCountry = africa;
				GameObject.Find("africaPoly").GetComponent<CountryController>().isLocked = false; 
				break; 
			default:
				break; 
			}

		}
	}


}
