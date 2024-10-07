using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    GameObject VObjP;
    GameObject NObjP;

    void Start()
    {
        VObjP = transform.GetChild(0).gameObject;
        NObjP = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (GameManager.Instance.VEyesON)
        {
            if(!VObjP.activeInHierarchy)
                VObjP.SetActive(true);

        }
        else
        {
            if (VObjP.activeInHierarchy)
                VObjP.SetActive(false);
        }


        if (GameManager.Instance.NEyesON)
        {
            if (!NObjP.activeInHierarchy)
                NObjP.SetActive(true);
        }
        else
        {
            if (NObjP.activeInHierarchy)
                NObjP.SetActive(false);
        }
    }
}
