using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    // Start is called before the first frame update
    public float XSmooth = 8;//x方向每秒的移动量
    public float YSmooth = 8;//y
    public float XDistance = 2;//X方向的Distance大于2就要移动
    public float YDistance = 2;

    public Vector2 MaxXandY;//存放最大的x,y
    public Vector2 MinXandY;
    public Transform Hero;

    void Start()
    {
        Hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool MoveX()//x方向移动函数
    {
        if (Mathf.Abs(Hero.position.x - transform.position.x) > XDistance)//英雄的位置-摄像机的位置 > x方向最大值 （取了绝对值  正负两个方向）
            return true;
        else
            return false;
    }

    void FollowHero()//跟随英雄函数
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (MoveX())//确定x方向需要移动
            newX = Mathf.Lerp(transform.position.x, Hero.position.x,XSmooth * Time.deltaTime);//算新的x ；Lerp函数（a,b,t）从a移动到b,t表示比例因素；eg：t=0.1表示从0-100的十分之一   摄像机位置，英雄位置，每秒移动*时间
        newX = Mathf.Clamp(newX, MinXandY.x, MaxXandY.x);//限制newx在最大和最小的中间，若<min 返回min，反之同

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        FollowHero();
    }
}
