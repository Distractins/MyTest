using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject explosion;//�ڵ�ʵ������ըЧ����ʵ����Ԥ����

    void Start()
    {
       //Destroy(gameObject, 2);//1s���Ժ�����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    private void OnTriggerEnter2D(Collider2D collision)//��collision��������ײ���Ķ���,˳��ִ�к���
    {
        if(collision.gameObject.tag != "Player")//�����ײ���Ķ���
        {

            float rotation = Random.Range(0, 360);//��������Ķ�������ֵ����ת�Ƕ�
            Instantiate(explosion,transform.position, Quaternion.Euler(0,0,rotation));//nstantiate����ʵ������������¡���ߴ��죩,x,y,���䣬z����ת
            Destroy(gameObject);//�����Լ�
        }
    }
}
