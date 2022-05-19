using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D HeroBody;
    public float MaxSpeed=5;
    public float MoveForce = 100.0f;//
    GameObject ufo;
    public bool bFaceRight = true;//�Ƿ�ת����ʼ�涨����ת��

    public bool bJump = false;//�ж�Уɫ�Ƿ���Ծ
    public float JumpForce = 100;//������������

    public Transform mGroundCheck;//���ó����еĿ����壬���߼������Ϊ�����жϵ�����


    //
    Animator anim;

        // Start is called before the first frame update
    void Start()
    {
        HeroBody = GetComponent<Rigidbody2D>();//��ȡ
        mGroundCheck = transform.Find("GroundCheck");//transform.Find�����ҵ�����ΪGroundCheck�����壬��������GroundCheck֮��
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//ÿһ֡���º���   fixedupdate �̶�����,�Լ����ù̶����µ�ʱ�䣬��0.1��0.01
    {
        //�����ƶ�
        float h;//�����ƶ�
        h = Input.GetAxis("Horizontal");//��������ƶ�
        if (Mathf.Abs(HeroBody.velocity.x) < MaxSpeed)//�����ٶ�С��maxspeed
        {
            HeroBody.AddForce(Vector2.right * h * MoveForce);
        }
        if (Mathf.Abs(HeroBody.velocity.x) > 5)//����
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed, HeroBody.velocity.y);
        }

        //hֵ����0.1�����ﶯ���͸ı�ΪRun
        anim.SetFloat("speed", Mathf.Abs(h));


        //ת��
        if (h > 0 && !bFaceRight) //��ת��
        {
            flip();
        }
        else if (h < 0 && bFaceRight)//ת��
        {
            flip();
        }

        //��Ծ   �жϼ���ɫ�Ƿ��ڵ���
        if (Physics2D.Linecast(transform.position, mGroundCheck.position,1 << LayerMask.NameToLayer("Ground")))
        //Linecast������transform.position, mGroundCheck.positionȷ������������������Ƿ��ڵ�����
        //1 << LayerMask.NameToLayer("Ground")���֮ǰ�����ĵ����
        {
            if (Input.GetButtonDown("Jump"))//������Ծ����jumpΪtrue
            {
                bJump = true;
            }
        }

    }

    private void flip()//ת�����ʵ��
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
    //��Ծ
    private void FixedUpdate()//�̶����º���
    {
     //�����������
        if (bJump)//���jumpΪ��ʱ
        {
            HeroBody.AddForce(Vector2.up * JumpForce);//����Ϊ��ɫ��Ӹ�����
            bJump = false;//�Ѿ���������������ֵΪfalse
            anim.SetTrigger("jump");
        }
    }

}
