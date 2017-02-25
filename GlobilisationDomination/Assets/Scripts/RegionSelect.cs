using UnityEngine;
using System.Collections;

public class RegionSelect : MonoBehaviour {

	public GameObject countryInfo;
	public GameObject countryUnlock;

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

					if (!CountryController.selectedCountry.GetComponent<CountryController> ().isLocked) {
						countryInfo.SetActive (true);
						CountryController cc = CountryController.selectedCountry.GetComponent<CountryController> ();
						cc.SetOutlineCol (new Vector4 (107, 130, 103, 255));
					} else {
						countryInfo.SetActive (false);
						//countryUnlock.SetActive (true);
					}
					Debug.Log (CountryController.selectedCountry);
				} else {
					if (CountryController.selectedCountry != null) 
					{
						CountryController c = CountryController.selectedCountry.GetComponent<CountryController> ();
						c.SetOutlineCol (new Vector4 (0, 0, 0, 0));
					}
					countryInfo.SetActive (false);
					//countryUnlock.SetActive (false);
				}

				if (hit.collider.tag == ("pickup"))
				{
					GameObject.Destroy (hit.collider.gameObject);
					money.moneyValue += hit.collider.gameObject.GetComponent<collectMoney> ().value;
				}
			}
		}
	}
}
