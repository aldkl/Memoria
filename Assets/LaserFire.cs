using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    float FireTime;
    float RotateSpeed;

    public float MaxFireTime;
    bool OnFire;

    int Num;

    public GameObject FireEffect;

    BoxCollider myBoxCollider;
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        FireTime += Time.deltaTime;
        if (MaxFireTime <= FireTime)
        {
            if (OnFire)
            {
                OnFire = false;
                //FireEffect[0].SetActive(true);
                //for (int i = 0; i < FireEffect.Length; i++)
                //{
                //    FireEffect[i].GetComponent<ParticleSystem>().Play();
                //}
                FireEffect.SetActive(true);

                FireEffect.GetComponent<ParticleSystem>().Play();

                StartCoroutine(BoXCl());
            }
            else
            {
                OnFire = true;
                FireEffect.SetActive(false);
                myBoxCollider.enabled = false;
            }
            FireTime = 0;
        }


        IEnumerator BoXCl()
        {
            yield return new WaitForSeconds(1.4f);

            myBoxCollider.enabled = true;
        }
        //if (OnFire)
        //{

        //}
        //else
        //{
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Player.transform.position = GameManager.Instance.RespawnPoint;
        }
    }
}
