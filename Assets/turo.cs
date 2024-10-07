using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turo : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject Tuto;
    public GameObject TutoBack;
    public GameObject TutoQuit;

    public void Btn()
    {
        Tuto.SetActive(false);
        TutoBack.SetActive(true);
        TutoQuit.SetActive(true);
    }
    public void Btn222()
    {
        Tuto.SetActive(true);
        TutoBack.SetActive(false);
        TutoQuit.SetActive(false);
    }
}
