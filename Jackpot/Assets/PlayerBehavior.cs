using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg);
        Debug.Log(GameManager.gameManager.playerHealth.Health);
    }

    private void PlayerHeal (int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);

    }
}
