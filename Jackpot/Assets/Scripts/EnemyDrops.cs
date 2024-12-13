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

    public Transform me;

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
        DropLoot();
    }

    public void DropLoot()
    {
        if (calculatedDropChance <= 25)
        {
            Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (calculatedDropChance <= 35 && calculatedDropChance >= 26)
        {
            Instantiate(healingitem, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (calculatedDropChance <= 50 && calculatedDropChance >= 36)
        {
            int calculatedUpgradeDropChance = Random.Range (0,3);
            if (calculatedUpgradeDropChance <= 1)
            {
                Instantiate(magazineup, transform.position, Quaternion.identity);
            }
            if (calculatedUpgradeDropChance == 2)
            {
                Instantiate(rapidfire, transform.position, Quaternion.identity);
            }
            if (calculatedUpgradeDropChance == 3)
            {
                Instantiate(bulletup, transform.position, Quaternion.identity);
            }
        }
    }
}
