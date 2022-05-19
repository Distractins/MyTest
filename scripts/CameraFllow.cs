using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    // Start is called before the first frame update
    public float XSmooth = 8;//x����ÿ����ƶ���
    public float YSmooth = 8;//y
    public float XDistance = 2;//X�����Distance����2��Ҫ�ƶ�
    public float YDistance = 2;

    public Vector2 MaxXandY;//�������x,y
    public Vector2 MinXandY;
    public Transform Hero;

    void Start()
    {
        Hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool MoveX()//x�����ƶ�����
    {
        if (Mathf.Abs(Hero.position.x - transform.position.x) > XDistance)//Ӣ�۵�λ��-�������λ�� > x�������ֵ ��ȡ�˾���ֵ  ������������
            return true;
        else
            return false;
    }

    void FollowHero()//����Ӣ�ۺ���
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (MoveX())//ȷ��x������Ҫ�ƶ�
            newX = Mathf.Lerp(transform.position.x, Hero.position.x,XSmooth * Time.deltaTime);//���µ�x ��Lerp������a,b,t����a�ƶ���b,t��ʾ�������أ�eg��t=0.1��ʾ��0-100��ʮ��֮һ   �����λ�ã�Ӣ��λ�ã�ÿ���ƶ�*ʱ��
        newX = Mathf.Clamp(newX, MinXandY.x, MaxXandY.x);//����newx��������С���м䣬��<min ����min����֮ͬ

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        FollowHero();
    }
}
