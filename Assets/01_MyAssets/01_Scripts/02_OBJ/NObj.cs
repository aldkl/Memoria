using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NObj : MonoBehaviour
{

    public bool IsVision;

    void Start()
    {
        
    }

    void Update()
    {
        IsVision = GameManager.Instance.NEyesON;
    }
}
