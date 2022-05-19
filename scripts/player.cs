using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D HeroBody;
    public float MaxSpeed=5;
    public float MoveForce = 100.0f;//
    GameObject ufo;
    public bool bFaceRight = true;//是否转身（开始规定可以转身）

    public bool bJump = false;//判断校色是否跳跃
    public float JumpForce = 100;//定义起跳力量

    public Transform mGroundCheck;//引用场景中的空物体，射线检测中作为辅助判断的物体


    //
    Animator anim;

        // Start is called before the first frame update
    void Start()
    {
        HeroBody = GetComponent<Rigidbody2D>();//获取
        mGroundCheck = transform.Find("GroundCheck");//transform.Find函数找到名字为GroundCheck的物体，并保存在GroundCheck之中
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//每一帧更新函数   fixedupdate 固定更新,自己设置固定更新的时间，如0.1，0.01
    {
        //左右移动
        float h;//横向移动
        h = Input.GetAxis("Horizontal");//输入横向移动
        if (Mathf.Abs(HeroBody.velocity.x) < MaxSpeed)//物体速度小于maxspeed
        {
            HeroBody.AddForce(Vector2.right * h * MoveForce);
        }
        if (Mathf.Abs(HeroBody.velocity.x) > 5)//大于
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed, HeroBody.velocity.y);
        }

        //h值大于0.1，人物动作就改变为Run
        anim.SetFloat("speed", Mathf.Abs(h));


        //转身
        if (h > 0 && !bFaceRight) //不转身
        {
            flip();
        }
        else if (h < 0 && bFaceRight)//转身
        {
            flip();
        }

        //跳跃   判断检测角色是否在地上
        if (Physics2D.Linecast(transform.position, mGroundCheck.position,1 << LayerMask.NameToLayer("Ground")))
        //Linecast函数；transform.position, mGroundCheck.position确定空物体两点的连线是否在地面上
        //1 << LayerMask.NameToLayer("Ground")检测之前创建的地面层
        {
            if (Input.GetButtonDown("Jump"))//按下跳跃键，jump为true
            {
                bJump = true;
            }
        }

    }

    private void flip()//转身代码实现
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
    //跳跃
    private void FixedUpdate()//固定更新函数
    {
     //添加起跳功能
        if (bJump)//检测jump为真时
        {
            HeroBody.AddForce(Vector2.up * JumpForce);//可以为角色添加刚体力
            bJump = false;//已经起跳后设置起跳值为false
            anim.SetTrigger("jump");
        }
    }

}
