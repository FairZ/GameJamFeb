using UnityEngine;
using System.Collections;

public class collectMoney : MonoBehaviour {

	public int value; 

	public void Collect()
	{
		//Do some stuff here with money and object deletion


		//Audio stuff
		AudioSource aRef = this.GetComponent<AudioSource>();
		aRef.clip = SoundController.moneyBagCollect;
		aRef.pitch = 1f; //Account for variance from appear sound
		aRef.pitch += Random.Range(-0.15f, 0.15f);
		aRef.Play ();
	}




}
