using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoritSpawn : MonoBehaviour
{

    public float meteoritCount, healthpackCount, portalCount; //количество метеоритов
    [SerializeField] GameObject meteorit, healthpack, portalObj;
    GameObject spawnObj;
    [SerializeField] GameObject Player;
    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<moveShip>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (meteoritCount > 0 || healthpackCount > 0 || portalCount > 0) //спавн метеоритов
        {
            Vector3 distanceVector = new Vector3(
                                                Random.Range(100, 200) * RandMinus(),
                                                Random.Range(100, 200) * RandMinus(),
                                                Random.Range(100, 200) * RandMinus()
                                                );
            if (meteoritCount > 0)
            {
                spawnObj = meteorit; //спавнить метеориты
                meteoritCount--;
            }
            else
                if (healthpackCount > 0)
				{
					spawnObj = healthpack; //спавнить аптечки
					healthpackCount--;
				}
				else
				{
					spawnObj = portalObj; //спавнить портал
					portalCount--;
				}
            Instantiate(spawnObj,
            Player.transform.position + distanceVector,
            Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }
    }
    float RandMinus() // возвращает -1 или 1
    {
        float minus;
        if (Random.Range(0, 2) == 1) minus = -1; else minus = 1;
        return minus;
    }
}
