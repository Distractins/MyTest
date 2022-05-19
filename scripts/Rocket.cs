using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject explosion;//炮弹实例化爆炸效果，实例化预制体

    void Start()
    {
       //Destroy(gameObject, 2);//1s钟以后销毁
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    private void OnTriggerEnter2D(Collider2D collision)//“collision”代表碰撞到的对象,顺序执行函数
    {
        if(collision.gameObject.tag != "Player")//检测碰撞到的对象
        {

            float rotation = Random.Range(0, 360);//产生随机的度数，赋值给旋转角度
            Instantiate(explosion,transform.position, Quaternion.Euler(0,0,rotation));//nstantiate就是实例化函数（克隆或者创造）,x,y,不变，z轴旋转
            Destroy(gameObject);//销毁自己
        }
    }
}
