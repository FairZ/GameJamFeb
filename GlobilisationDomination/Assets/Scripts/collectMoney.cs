using UnityEngine;
using System.Collections;

public class collectMoney : MonoBehaviour {

	public int value; 

	private bool isRising = true;

	private Material[] matRefs;

	//Relative to the factory
	private const float heightLimit = 10f;
	private Vector3 startPos;

	private const float timeoutMax = 10.0f;
	private float timeout = timeoutMax;

	void Start()
	{
		startPos = this.transform.position;
		matRefs = this.GetComponents<Material> ();
	}

	void Update()
	{
		if (isRising)
		{
			if (Vector3.Distance (this.transform.position, startPos) > heightLimit) 
			{
				isRising = false;
			}
			else 
			{
				//Move it by delta time
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

		this.transform.Translate (this.transform.up * Time.deltaTime);

	}

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
