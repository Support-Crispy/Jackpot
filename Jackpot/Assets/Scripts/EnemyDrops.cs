using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject coin;
    public GameObject healingitem;
    public GameObject magazineup;
    public GameObject bulletup;
    public GameObject rapidfire;

    public int calculatedDropChance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateLoot()
    {
        int calculatedDropChance = Random.Range (0, 50);
    }

    public void DropLoot()
    {
        if (calculatedDropChance <= 25)
        {
            Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
