using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [Header("Health")]
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public GameObject body;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    public float durationTimer;

    [Header("Heal Overlay")]
    public Image overlay2;
    public float duration2;
    public float fadeSpeed2;

    public float durationTimer2;

    public GameObject respawnMenuUI;


    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha); 
            }
        }
        if (overlay2.color.a > 0)
        {
            durationTimer2 += Time.deltaTime;
            if (durationTimer2 > duration2)
            {
                float tempAlpha2 = overlay2.color.a;
                tempAlpha2 -= Time.deltaTime * fadeSpeed2;
                overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, tempAlpha2); 
            }
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1); 
        if (health <= 0)
        {
            Death();
        }
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        durationTimer2 = 0;
        overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, 1); 
    }

    public void Death()
    {
        DeathMenu();
        Destroy(body);
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }

        if (collision.gameObject.tag == "Healing")
        {
            RestoreHealth(10);
        }
    }

    public void DeathMenu()
    {
        respawnMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }



}
