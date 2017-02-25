using UnityEngine;
using System.Collections;

public class RegionSelect : MonoBehaviour {

	void FixedUpdate(){
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 10000.0f))
			{
				if (hit.collider.tag == ("country"))
				{
					CountryController.selectedCountry = hit.collider.gameObject; 
					Debug.Log (CountryController.selectedCountry);
				}
			}
		}
	}
}
