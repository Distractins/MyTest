using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float parallaxFactor = 0.1f;//整体移动
    public float framesParllaxFactor = 0.3f;//每层移动
    public float smoothX = 4;
    public Transform[] backgrounds;


    private Transform cam; //获取相机的位置
    private Vector3 camPrePos; //存放上一帧的位置

    
    private void Awake()//awake获取
    {
        cam = Camera.main.transform;//获取摄像机transform
   
    }

    void Start()
    {
        camPrePos = cam.position;//主键位置信息存放在
    }

    //背景移动函数
    void bkParallax()//视差
    {
        float fparallax = (camPrePos.x - cam.position.x)* parallaxFactor;//相机的运动量*
        for(int i=0; i<backgrounds.Length; i++)
        {
            float bkNewX = backgrounds[i].position.x + fparallax * (1 + i * framesParllaxFactor); //(原先位置加上运动位置)每一层运动量
            Vector3 bkNewPos = new Vector3(bkNewX, backgrounds[i].position.y, backgrounds[i].position.z);//新位置
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bkNewPos,  Time.deltaTime * smoothX);//每一帧背景移动的位置
            camPrePos = cam.position;//把当前的相机作为上一帧的位置保存下来

        }
    }



    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
