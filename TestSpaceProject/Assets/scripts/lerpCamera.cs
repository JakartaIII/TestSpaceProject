using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpCamera : MonoBehaviour {
	[SerializeField] GameObject cameraPoint;
	public float lerpF,camDistance;
	// плавное движение камеры
	void FixedUpdate () {
	transform.position = cameraPoint.transform.position+transform.forward*camDistance;
	transform.rotation = Quaternion.Lerp(transform.rotation,cameraPoint.transform.rotation,lerpF);	
	}
	void Update()
	{
		MouseScrollInput();
	}
	void MouseScrollInput() //отдаление камеры
	{
		camDistance+= Input.GetAxis("Mouse ScrollWheel")*5;
		if(camDistance<-25) camDistance = -25;
		if(camDistance>0) camDistance = 0;
	}
	
}
