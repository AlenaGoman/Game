using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockEnd : MonoBehaviour
{

    [SerializeField] private GameObject Block;


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);

    }
}
