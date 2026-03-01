//using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public GameObject snake;//把蛇到时候拉上去
    UnityEngine.Vector3 topRight;//用来到时候生成随机坐标
    UnityEngine.Vector3 leftBottom;

    float randomX;//用来存取随机数。

    float yAboveMedium=3;//表示超出顶部的距离
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float yAbove;

    #region timer
    float spawnTime=3f;
    float timer=0;
    #endregion

    UnityEngine.Vector2 spawnPosition;//用来存储最终的生成位置
    void Start()
    {
        topRight=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        leftBottom=Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));//得到两个主坐标
        yAbove=yAboveMedium+topRight.y;//得到生成y的坐标位置
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=spawnTime){
        randomX=Random.Range(leftBottom.x,topRight.x);//随机生成一个x
        spawnPosition=new Vector2(randomX,yAbove);//随机生成坐标位置
        Instantiate(snake,spawnPosition,Quaternion.identity);//随机生成。
        timer=0;
        }
    }
}
