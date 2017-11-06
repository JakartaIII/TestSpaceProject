using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour {
	Rigidbody rigid;
	public float x,y,xR,yR; 
	public float speed, rotSpeed;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		InputKeys();
		RigidbodyMove();
	}
	void RigidbodyMove()
	{
		rigid.AddForce(transform.forward*y*speed);
		rigid.AddForce(transform.right*x*speed);
		rigid.AddTorque(transform.up*xR*rotSpeed);
		rigid.AddTorque(transform.right*-yR*rotSpeed);

	}
	void InputKeys()
	{		
		x =  Input.GetAxis("Horizontal");
		y =  Input.GetAxis("Vertical");
		xR =  Input.GetAxis("HorizontalRot");
		yR =  Input.GetAxis("VerticalRot");
	}
}
