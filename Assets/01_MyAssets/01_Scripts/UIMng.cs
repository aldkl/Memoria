using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMng : MonoBehaviour
{
    // Start is called before the first frame update

    public Image KeyImage;
    public Image BlackImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsKey)
        {
            if(!KeyImage.gameObject.activeSelf)
            {
                KeyImage.gameObject.SetActive(true);
            }
        }
        if(GameManager.Instance.Player.CState == CharacterControl.CharacterState.E)
        {
            if (!BlackImage.gameObject.activeSelf)
            {
                BlackImage.gameObject.SetActive(true);
            }
        }
        else
        {
            if (BlackImage.gameObject.activeSelf)
            {
                BlackImage.gameObject.SetActive(false);
            }
        }
    }
}
