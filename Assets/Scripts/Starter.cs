using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    float power;
    float minPower = 0f; // минимальное усилие для запуска шарика
    [SerializeField] float maxPower = 100; // максимальное усилие для запуска шарика
    [SerializeField] float powerStep = 4000; // шаг, с которым увеличивается усилие для шарика
    [SerializeField] Slider powerSlider; // отображение усилия для шарика

    private Rigidbody ball = null;
    bool ballReady; // отображать slider, только если шарик находится в месте старта



    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }

    void Update()
    {
        if(ball != null)
        {
            ballReady = true;

            if(Input.GetKey(KeyCode.Space)) // набираем силу для запуска шарика
            {
                if(power <= maxPower)
                {
                    power += powerStep * Time.deltaTime; // код будет работать с одинаковой скоростью
                }
            }

            if(Input.GetKeyUp(KeyCode.Space)) // при отпускании клавиши space шарик запускается
            {
                ball.AddForce(power * Vector3.forward);
            }

            powerSlider.gameObject.SetActive(ballReady);
            powerSlider.value = power;
        }
        else
        {
            ballReady = false;
            power = minPower;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ball"))
        {
            ball = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            ball = null;
        }
    }

}
