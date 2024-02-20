using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject HealthBar;
    private static Image HealthBarImage;
    public static float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(HealthBar != null) {
            HealthBarImage = HealthBar.transform.GetComponent<Image>();
        }

        SetHealthBarValue(health); 
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(health/100);
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

    /*
    void OnTriggerEnter(Collider other) {
        if(invincibility == false) {
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
        }
        if(other.gameObject.CompareTag("Fruit")) {
            health += 10.0f;
        }
        if(invincibility == true) {
            if(other.gameObject.CompareTag("BadPellet")) {
                health += 0;
            }
        }
        else {
            if(other.gameObject.CompareTag("BadPellet")) {
                health -= 10.0f;
            }
        }
    }
    */

    /*
    void OnTriggerStay(Collider other) {
        if(invinicbility == false) {
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
    */
}
