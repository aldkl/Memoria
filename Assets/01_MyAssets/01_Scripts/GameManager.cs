using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
    public void Start()
    {
        GameManager.Instance.NEyesON = true;
        GameManager.Instance.VEyesON = false;
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public bool IsKey;
    public List<GameObject> VObjects;
    public List<GameObject> NObjects;

    public CharacterControl Player;
    public Vector3 RespawnPoint;
    public bool VEyesON;
    public bool NEyesON;

    public GameObject IsChatObj;
}
