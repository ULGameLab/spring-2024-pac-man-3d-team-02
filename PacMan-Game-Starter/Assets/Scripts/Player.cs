using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject HealthBar;
    private static Image HealthBarImage;
    public static float health = 100.0f;

    public static Boolean hasMegachomp;
    public float maxPlayerSpeed = 7.0f;

    public GameObject StaminaBar;
    private static Image StaminaImage;
    public static float stamina = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(HealthBar != null) {
            HealthBarImage = HealthBar.transform.GetComponent<Image>();
        }


        SetHealthBarValue(health);


        if (StaminaBar != null)
        {
            StaminaImage = StaminaBar.transform.GetComponent<Image>();
        }

        SetStaminaBarValue(stamina);

        hasMegachomp = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(health/100);

        SetStaminaBarValue(stamina/100);
       
        if(stamina <= 50)
        {
            SimpleController.playerSpeed = maxPlayerSpeed - 2;
        } else
        {
            SimpleController.playerSpeed = maxPlayerSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Q) && hasMegachomp == false)
        {
            hasMegachomp = true;
            if (stamina >= 50 ) { stamina -= 50; } else { stamina = 0; }
            StartCoroutine(CountDown());
        }
    }

    public static void SetHealthBarValue(float value) {
        HealthBarImage.fillAmount = value;

        if (HealthBarImage.fillAmount < 0.5f) {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.7f) {
            SetHealthBarColor(Color.yellow);
        }
        else {
            SetHealthBarColor(Color.green);
        }
    }

    public static void SetHealthBarColor(Color healthColor) {
        HealthBarImage.color = healthColor;
    }

    public static float GetHealthBarValue() {
        return HealthBarImage.fillAmount;
    }

    public static void SetStaminaBarValue(float value)
    {
        StaminaImage.fillAmount = value;

        if (StaminaImage.fillAmount < 0.5f)
        {
            SetStaminaBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.7f)
        {
            SetStaminaBarColor(Color.yellow);
        }
        else
        {
            SetStaminaBarColor(Color.blue);
        }
    }

    public static void SetStaminaBarColor(Color staminaColor)
    {
        StaminaImage.color = staminaColor;
    }

    public static float GetStaminaBarValue()
    {
        return StaminaImage.fillAmount;
    }

    
    void OnTriggerEnter(Collider other) {
        if(hasMegachomp == false) {
            if (other.gameObject.CompareTag("Enemy")) {
                health -= 0.01f;
                if (health < 0) health = 0;
            }
            else {
                if (other.gameObject.CompareTag("Enemy")) {
                    health += 0;
                }
            }
        }
        if(other.gameObject.CompareTag("GoodPellet")) {
            health += 5.0f;
            stamina += 10.0f;
        }
        if(other.gameObject.CompareTag("Fruit")) {
            health += 10.0f;
            stamina += 10.0f;
    }
        if(hasMegachomp == true) {
            if(other.gameObject.CompareTag("ToxicPellet")) {
                health += 0;
            }
        }
        else {
            if(other.gameObject.CompareTag("ToxicPellet")) {
                health -= 10.0f;
            }
        }
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(10);

        hasMegachomp = false;
    }


    void OnTriggerStay(Collider other) {
        if(hasMegachomp == false) {
            if (other.gameObject.CompareTag("Enemy")) {
                health -= 0.01f;
                if (health < 0) health = 0;
            }
        }
        else {
            if (other.gameObject.CompareTag("Enemy")) {
                health += 0;
            }
        }
    }
}
