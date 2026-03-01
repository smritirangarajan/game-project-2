using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    #region randomPos
    UnityEngine.Vector3 leftBottom;
    UnityEngine.Vector3 topRight;
    UnityEngine.Vector2 spawnPosition;
    float randomX;
    float yAboveMedium=3;
    float yAbove;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region timer
    float spawnTime=6f;
    float timer=0;
    #endregion

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
        if(timer>=spawnTime)
        {
        randomX=Random.Range(leftBottom.x,topRight.x);//随机生成一个x
        spawnPosition=new Vector2(randomX,yAbove);//随机生成坐标位置
        Instantiate(coin,spawnPosition,Quaternion.identity);//随机生成。
        timer=0;
        }
    }
}
