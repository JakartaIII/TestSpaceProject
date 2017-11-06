using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScene : MonoBehaviour {
	public bool SecondSceen;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			if(SecondSceen)
			{
				Application.LoadLevel(0);
			} 
			else
			{
				Application.LoadLevel(1);
			}
		}
	}
}
