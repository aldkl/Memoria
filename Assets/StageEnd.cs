using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.IsKey)
            {
                GameManager.Instance.IsChatObj.SetActive(true);

            }
        }
    }
}
