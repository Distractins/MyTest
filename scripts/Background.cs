using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float parallaxFactor = 0.1f;//�����ƶ�
    public float framesParllaxFactor = 0.3f;//ÿ���ƶ�
    public float smoothX = 4;
    public Transform[] backgrounds;


    private Transform cam; //��ȡ�����λ��
    private Vector3 camPrePos; //�����һ֡��λ��

    
    private void Awake()//awake��ȡ
    {
        cam = Camera.main.transform;//��ȡ�����transform
   
    }

    void Start()
    {
        camPrePos = cam.position;//����λ����Ϣ�����
    }

    //�����ƶ�����
    void bkParallax()//�Ӳ�
    {
        float fparallax = (camPrePos.x - cam.position.x)* parallaxFactor;//������˶���*
        for(int i=0; i<backgrounds.Length; i++)
        {
            float bkNewX = backgrounds[i].position.x + fparallax * (1 + i * framesParllaxFactor); //(ԭ��λ�ü����˶�λ��)ÿһ���˶���
            Vector3 bkNewPos = new Vector3(bkNewX, backgrounds[i].position.y, backgrounds[i].position.z);//��λ��
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bkNewPos,  Time.deltaTime * smoothX);//ÿһ֡�����ƶ���λ��
            camPrePos = cam.position;//�ѵ�ǰ�������Ϊ��һ֡��λ�ñ�������

        }
    }



    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
