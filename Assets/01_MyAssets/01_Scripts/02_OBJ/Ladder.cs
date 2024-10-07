using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Player.bIsLadder = true;
            GameManager.Instance.Player.PlayerRigidbody.useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Player.bIsLadder = false;
            GameManager.Instance.Player.PlayerRigidbody.useGravity = true;

        }
    }
}