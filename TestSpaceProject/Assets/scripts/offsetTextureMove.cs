using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetTextureMove : MonoBehaviour {
 [SerializeField] Material PortalTexture;
 public float x;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x+=Time.deltaTime*0.5f;
		if(x>100) x =0; 
		PortalTexture.mainTextureOffset = new Vector2(1,x);
	}
}
