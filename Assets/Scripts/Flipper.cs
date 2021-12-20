using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float restPos = 0f; // начальная позиция слиппера
    [SerializeField] private float pressedPos = 45f; // максимальное отклонение от позиции
    [SerializeField] private float hitStrength = 10000f; // сила, с которой слиппер толкает шарик при столкновении
    [SerializeField] private float flipperDamper = 150f;

    [SerializeField] private bool leftFlipper;

    private HingeJoint hinge;
    private JointSpring spring;


    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }


    void Update()
    {
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if(leftFlipper && Input.GetAxis("Horizontal") < 0
            || !leftFlipper && Input.GetAxis("Horizontal") > 0)
        {
            spring.targetPosition = pressedPos;
        }
        else
        {
            spring.targetPosition = restPos;
        }

        hinge.spring = spring;
    }
}
