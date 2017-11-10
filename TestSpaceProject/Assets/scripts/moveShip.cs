using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class moveShip : MonoBehaviour {
	Rigidbody rigid;
	public float x,y,xR,yR,xM,yM; // input клавиатура и мышь 
	bool LKM, PKM; //нажатие кнопок мыши
	public float speed, rotSpeed; //скорость 
	bool isCanon1; // какая пушка стреляет
	float shootTimer;// таймер выстрела
	[SerializeField] GameObject  canon1, canon2; // точки выстрела
	[SerializeField] Rigidbody rocket; //ракета обьект
	public float health = 100; //здоровье
	public float meteoritsCount; //количество метеоритов уничтожено
	float invincTime;//время после получения урона
	bool shipDestroyed;
	[SerializeField] Text healthText, meteoritText; 
	[SerializeField] ParticleSystem ParticleEm;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		health = FindObjectOfType<savedSceneData>().health;
		meteoritsCount = FindObjectOfType<savedSceneData>().meteorCount;
	}
	
	// Update is called once per frame
	void Update () {
		InputVariables();
		if(health>0)
		{
            RigidbodyMove();
			if(!EventSystem.current.IsPointerOverGameObject()) Shooting();
            shipDestroyed = false;
        }
		else 
		{
			if (!shipDestroyed)
            {
				Cursor.lockState = CursorLockMode.None;
           		Cursor.visible = true;
                FindObjectOfType<savedSceneData>().AddLogText("-корабль уничтожен");
                shipDestroyed = true;
            }
		}
		if(health>100) health =100;
		if(health<0) health = 0;
		if(invincTime>0)invincTime-=Time.deltaTime;
		ParticleEmis();
		healthText.text = ""+health;
		meteoritText.text = ""+meteoritsCount;

	}
	void RigidbodyMove()
	{
		//Движение вперед/назад, влево/вправо
		rigid.AddForce(transform.forward*y*speed * Time.deltaTime);
		rigid.AddForce(transform.right*x*speed* Time.deltaTime);
		//Повороты клавишами вверх/вниз налево/направо
		rigid.AddTorque(transform.up*xR*rotSpeed* Time.deltaTime);
		rigid.AddTorque(transform.right*-yR*rotSpeed* Time.deltaTime);
		//Повороты мышью вверх/вниз, налево/направо
		if(PKM) 
		{
			Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
			rigid.AddTorque(transform.up*xM*rotSpeed* Time.deltaTime);
			rigid.AddTorque(transform.right*-yM*rotSpeed* Time.deltaTime);
		} else
		{
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}

	}
	void ParticleEmis()
	{
		var mainp = ParticleEm.main;
		if(shipDestroyed) mainp.simulationSpeed = 1;
		else
		mainp.simulationSpeed =1+16*y ;
	}
	void Shooting()
	{
		if(LKM||Input.GetKey(KeyCode.RightControl))
		{
			if(shootTimer<=0)
			{
				Rigidbody rocketClone;
				if(isCanon1) 
				{
					rocketClone = (Rigidbody) Instantiate(rocket, canon1.transform.position, transform.rotation);
    				rocketClone.velocity = rigid.velocity;
					//Instantiate(rocket, canon1.transform.position,transform.rotation);
					isCanon1 = false;
				}
				else 
				{
					rocketClone = (Rigidbody) Instantiate(rocket, canon2.transform.position, transform.rotation);
    				rocketClone.velocity = rigid.velocity;
					//Instantiate(rocket, canon2.transform.position,transform.rotation);
					isCanon1 = true;
				}
				shootTimer =0.5f;
			}
		}
		if(shootTimer>0) shootTimer-=Time.deltaTime;
	}
	void InputVariables()
	{		
		x =  Input.GetAxis("Horizontal");
		y =  Input.GetAxis("Vertical");
		xR =  Input.GetAxis("HorizontalRot");
		yR =  Input.GetAxis("VerticalRot");
		xM =  Input.GetAxis("Mouse X");
		yM =  Input.GetAxis("Mouse Y");
		PKM = Input.GetButton("Fire2");
		LKM = Input.GetButton("Fire1");
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Meteor"&&invincTime<=0)
		{
			FindObjectOfType<savedSceneData>().AddLogText("-корабль столкнулся с метеоритом");
			health-=Random.Range(10,30);
			invincTime = 2;
		}		
		if(other.gameObject.tag=="HealthPack")
		{
			FindObjectOfType<savedSceneData>().AddLogText("-корабль пополнил здоровье");
			FindObjectOfType<meteoritSpawn>().healthpackCount++;
			health+=20;
			Destroy(other.gameObject);
			rigid.angularVelocity = new Vector3(0,0,0);
		}	
	}
}
