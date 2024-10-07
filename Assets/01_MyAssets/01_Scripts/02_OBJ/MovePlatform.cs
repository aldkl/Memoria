using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //    MyTransform = GetComponent<Transform>();
    //}
    //Transform MyTransform;

    //bool Left;
    //public float MoveSpeed;

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Left)
    //    {
    //        MyTransform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);

    //    }
    //    else
    //    {
    //        MyTransform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Ground"))
    //    {
    //        if (Left)
    //            Left = false;
    //        else
    //            Left = true;
    //    }
    //}

    public List<Vector3> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 10;


    private void Start()
    {
        platform = GetComponent<Transform>();
    }
    private void Update()
    {
        //MoveToNextPoint();
    }

    private void FixedUpdate()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        //�÷��� ��ġ ����(goal point�� ������)
        platform.position = Vector3.MoveTowards(platform.position, points[goalPoint], Time.deltaTime * moveSpeed);
        //���� point�� �����ߴ��� üũ
        if (Vector3.Distance(platform.position, points[goalPoint]) < 0.1f)
        {
            //�����ߴٸ� ���� goal point�� ����
            //������ goal point�� �����ߴ��� Ȯ�� ��, ó�� point�� ����
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;
        }

    }
}
