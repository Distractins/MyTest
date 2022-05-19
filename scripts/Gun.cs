using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rocket;
    public float speed= 20f;//控制子弹发射的速度

    private player player; //获取角色当前的朝向

    //private Animation anim;//获取角色anim主件
    // Start is called before the first frame update
    void Start()
    {
        //anim = transform.root.GetComponent<Animation>();
        player = transform.root.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//按下fire键，鼠标左键
        {
            //audio.play();//射击时的枪声
            if(player.bFaceRight)//检测角色朝向，面向右为真
            {
                GameObject bulletInstance = Instantiate(rocket,new Vector2(transform.position.x-1.4f,transform.position.y-0.8f), Quaternion.Euler(0, 0, 0));//创建子弹,transform.position为一开始发射位置
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(speed, 0);
            }
            else//角色向左运动
            {
                GameObject bulletInstance = Instantiate(rocket, new Vector2(transform.position.x +1.4f, transform.position.y+0.8f), Quaternion.Euler(0, 0, 180));//旋转180°  调整子弹角度
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-speed, 0);//角色负方向
            }
        }
    }
}
