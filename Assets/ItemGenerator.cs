using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    //Prefabを入れる
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    //スタート地点、値を-200に修正
    private int startPos = -200;
    //ゴール地点
    private int goalPos = 120;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテムを出すz方向の範囲
    private float posRangeZ = 50;

    //Unityちゃん
    private GameObject unityChan;
    //アイテムを生成する地点
    private int i;

    // Use this for initialization
    void Start () {
        //Unityちゃんを取得
        this.unityChan = GameObject.Find("unitychan");
        //iを初期化
        i = startPos;
    }

    // Update is called once per frame
    void Update()
    { 
        if (i < this.unityChan.transform.position.z + posRangeZ && i < goalPos)
        {
            ItemGeneration(i);
            i += 15;
        }
    }

    void ItemGeneration(int i)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(0, 10);
        if (num <= 1)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j < 2; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くz座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置：30%車配置：10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                }
            }
        }
    }
}
