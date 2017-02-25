using UnityEngine;
using System.Collections;

public class RegionSelect : MonoBehaviour {

	public GameObject countryInfo;

	void FixedUpdate(){
		if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 10000.0f))
			{
				if (hit.collider.tag == ("country")) {
					CountryController.selectedCountry = hit.collider.gameObject; 
					if (!CountryController.selectedCountry.GetComponent<CountryController> ().isLocked) {
						countryInfo.SetActive (true);
					} else {
						countryInfo.SetActive (false);
					}
					Debug.Log (CountryController.selectedCountry);
				} else {
					countryInfo.SetActive (false);
				}
			}
		}
	}
}
