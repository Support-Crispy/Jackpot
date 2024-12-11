using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    public TextMeshProUGUI coinCount;

    public int coinAmount;

    string coinCountString;

    public ProjectileGun projectileGun;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCountString = coinAmount.ToString();

        if (coinCount != null)
            coinCount.SetText(coinCountString);
    }

    public void CollectCoin(int collectAmount)
    {
        coinAmount += collectAmount;
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Coin")
        {
            CollectCoin(10);
        }
        if (collision.gameObject.tag == "Magazine")
        {
          projectileGun.magazineSize += 1;
        }
        if (collision.gameObject.tag == "FireUp")
        {
            projectileGun.timeBetweenShooting -= 1;
        }
        if (collision.gameObject.tag == "MoreBullets")
        {
            projectileGun.bulletsPerTap += 1;
        }
    }
}
