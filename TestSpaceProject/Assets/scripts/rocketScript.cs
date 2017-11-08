using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Meteor")
		{
			FindObjectOfType<meteoritSpawn>().meteoritCount++;
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
