using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Renderer[] _RendererBack;
    //public GameObject[] BackGroundOBJs;

    public Texture2D[] VTexture2Ds;
    public Texture2D[] VNTexture2Ds;
    public Texture2D[] NTexture2Ds;

    public CharacterControl.CharacterState CurState;
    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < transform.GetChild(2).childCount; i++)
        //{
        //    BackGroundOBJs[i] = transform.GetChild(i).gameObject;
        //    _RendererBack[i] = BackGroundOBJs[i].GetComponent<Renderer>();
        //}

        //for (int i = 0; i < BackGroundOBJs.Length; i++)
        //{
        //    _RendererBack[i] = BackGroundOBJs[i].GetComponent<MeshRenderer>();
        //    Debug.Log("asdasdzzczxc");
        //}
    }

    bool changeState(CharacterControl.CharacterState NewState)
    {
        if (CurState == NewState) return false;

        CurState = NewState;
        return true;
    }

    void Aasd(int i, int j)
    {
        switch (CurState)
        {
            case CharacterControl.CharacterState.N:
                    _RendererBack[i].material.mainTexture = NTexture2Ds[j];
                break;

            case CharacterControl.CharacterState.V:
                    _RendererBack[i].material.mainTexture = VTexture2Ds[j];
                break;

            case CharacterControl.CharacterState.VN:
                    _RendererBack[i].material.mainTexture = VNTexture2Ds[j];
                break;

            case CharacterControl.CharacterState.E:

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (changeState(GameManager.Instance.Player.CState))
        {
            for (int i = 0; i < _RendererBack.Length; i++)
            {
                switch(_RendererBack[i].tag)
                {
                    case "Build1":
                        Aasd(i, 0);
                        break;
                    case "Build2":
                        Aasd(i, 1);
                        break;
                    case "Build3":
                        Aasd(i, 2);
                        break;
                    case "Build4":
                        Aasd(i, 3);
                        break;
                    case "Build5":
                        Aasd(i, 4);
                        break;
                    case "Build6":
                        Aasd(i, 5);
                        break;
                    case "Build7":
                        Aasd(i, 6);
                        break;
                    case "Ground":
                        Aasd(i, 7);
                        break;
                    case "Ladder":
                        Aasd(i, 8);
                        break;
                    case "Platform":
                    case "MovePlatform":
                        Aasd(i, 9);
                        break;
                    case "Column":
                        Aasd(i, 10);
                        break;
                    case "Gate":
                        Aasd(i, 11);
                        break;
                    case "Wall":
                        Aasd(i, 12);
                        break;
                }
            }
        }
    }
}
