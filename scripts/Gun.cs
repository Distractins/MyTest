using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rocket;
    public float speed= 20f;//�����ӵ�������ٶ�

    private player player; //��ȡ��ɫ��ǰ�ĳ���

    //private Animation anim;//��ȡ��ɫanim����
    // Start is called before the first frame update
    void Start()
    {
        //anim = transform.root.GetComponent<Animation>();
        player = transform.root.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//����fire����������
        {
            //audio.play();//���ʱ��ǹ��
            if(player.bFaceRight)//����ɫ����������Ϊ��
            {
                GameObject bulletInstance = Instantiate(rocket,new Vector2(transform.position.x-1.4f,transform.position.y-0.8f), Quaternion.Euler(0, 0, 0));//�����ӵ�,transform.positionΪһ��ʼ����λ��
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(speed, 0);
            }
            else//��ɫ�����˶�
            {
                GameObject bulletInstance = Instantiate(rocket, new Vector2(transform.position.x +1.4f, transform.position.y+0.8f), Quaternion.Euler(0, 0, 180));//��ת180��  �����ӵ��Ƕ�
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-speed, 0);//��ɫ������
            }
        }
    }
}
