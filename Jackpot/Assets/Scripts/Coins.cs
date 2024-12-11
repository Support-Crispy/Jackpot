using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
