using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceObjScript : MonoBehaviour {
	[SerializeField] GameObject Player;
	public float range;
	public bool isMeteor,isHealthPack,isPortal;
	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<moveShip>().gameObject;
		if(!isPortal)
		{
		if(!isHealthPack)
		{
            float scaleMeteor = Random.Range(1, 20);
            transform.localScale = new Vector3(scaleMeteor, scaleMeteor, scaleMeteor);
        }
		float velocityMeteor = 10;
		GetComponent<Rigidbody>().velocity = transform.forward + 
		new Vector3(Random.Range(-velocityMeteor,velocityMeteor),
					Random.Range(-velocityMeteor,velocityMeteor),
					Random.Range(-velocityMeteor,velocityMeteor));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Magnitude(transform.position-Player.transform.position)>500f)
		{
			if(isMeteor)
			{
				FindObjectOfType<meteoritSpawn>().meteoritCount++;
			}
			if(isHealthPack)
			{
				FindObjectOfType<meteoritSpawn>().healthpackCount++;
			}
			if(isPortal)
			{
				FindObjectOfType<meteoritSpawn>().portalCount++;
			}
			Destroy(this.gameObject);
		}
	}
}
