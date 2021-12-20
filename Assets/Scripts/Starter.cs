using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    float power;
    float minPower = 0f; // ����������� ������ ��� ������� ������
    [SerializeField] float maxPower = 100; // ������������ ������ ��� ������� ������
    [SerializeField] float powerStep = 4000; // ���, � ������� ������������� ������ ��� ������
    [SerializeField] Slider powerSlider; // ����������� ������ ��� ������

    private Rigidbody ball = null;
    bool ballReady; // ���������� slider, ������ ���� ����� ��������� � ����� ������



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

            if(Input.GetKey(KeyCode.Space)) // �������� ���� ��� ������� ������
            {
                if(power <= maxPower)
                {
                    power += powerStep * Time.deltaTime; // ��� ����� �������� � ���������� ���������
                }
            }

            if(Input.GetKeyUp(KeyCode.Space)) // ��� ���������� ������� space ����� �����������
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
