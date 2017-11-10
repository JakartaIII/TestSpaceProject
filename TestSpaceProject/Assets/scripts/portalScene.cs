using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScene : MonoBehaviour {
	public bool SecondSceen;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			if(SecondSceen)
			{
				FindObjectOfType<savedSceneData>().AddLogText("-корабль переместился через портал");
				saveDataToNextScene();
				Application.LoadLevel(0);
			} 
			else
			{
				FindObjectOfType<savedSceneData>().AddLogText("-корабль переместился через портал");
				saveDataToNextScene();
				Application.LoadLevel(1);
			}
		}
	}
	void saveDataToNextScene()
	{
		FindObjectOfType<savedSceneData>().health = FindObjectOfType<moveShip>().health;
		FindObjectOfType<savedSceneData>().meteorCount = FindObjectOfType<moveShip>().meteoritsCount;
	}
}
