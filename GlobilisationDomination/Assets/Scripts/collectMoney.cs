using UnityEngine;
using System.Collections;

public class collectMoney : MonoBehaviour {

	public int value; 

	private bool isRising = true;

	//Relative to the factory
	private const float heightLimit = 1f / 9.5f;

	public GameObject parentFactory;

	private const float timeoutMax = 10.0f;
	private float timeout = timeoutMax;

	public AudioClip collectSound;

	void FixedUpdate()
	{
		if (isRising)
		{
			if (Vector3.Distance (this.transform.localPosition, parentFactory.transform.localPosition) > heightLimit) 
			{
				isRising = false;
			}
			else 
			{
				this.transform.Translate ((Vector3.up/2) * Time.deltaTime);
			}
		}
		else
		{
			timeout -= Time.deltaTime;

			if(timeout <= 0.0f)
			{
				Destroy (this.gameObject);
			}

		}
			
	}

	public void Collect()
	{
		//Do some stuff here with money and object deletion


		//Audio stuff
		AudioSource aRef = this.GetComponent<AudioSource>();
		//aRef.clip = SoundController.moneyBagCollect;
		aRef.pitch = 1f; //Account for variance from appear sound
		aRef.pitch += Random.Range(-0.15f, 0.15f);
		aRef.PlayOneShot (collectSound);
	}




}
