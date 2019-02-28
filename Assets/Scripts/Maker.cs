using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker : MonoBehaviour
{
    private float[] x_point;
    private float y_point = 2f;
    private float[] z_point;
    public GameObject Goblin;
    public GameObject Apple;
    public GameObject Poison;
    private int rand;
    private int min = 0;
    private int max = 8;
    private float[] Enemy_intreval;

    private static int Enemy_level = 0;
    private float[] Enemy_rotate;
    private float Apple_interval = 20f;
    private float[] Apple_point;
    private float Poison_interval = 40f;
    private float[] Poison_point;
 
public static int getLevel(){
    return Enemy_level;
}

    // Start is called before the first frame update
    void Start()
    {
        Enemy_intreval = new float[] {7f,5f,3f};//敵の出る間隔
        x_point = new float[] { -80f, 0f, 80, -80f, 80f, -80f, 0f, 80f };//原点はない
        z_point = new float[] { 80f, 80f, 80f, 0f, 0f, -80f, -80f, -80f };//原点はない
        Enemy_rotate = new float[] { 45f, 0f, -45f, 90f, -90f, 135f, 180f, -135f };//すべてが中央を向くように向きを合わせる
        Apple_point = new float[] { 80f, 5f, 50f };//リンゴのでるポイント
        Poison_point = new float[] { -80f, 5f, 50f };//毒アイテムの出るポイント

        InvokeRepeating("Make", 1f,Enemy_intreval[Enemy_level]);
        Invoke("Make_Apple", Apple_interval);
        Invoke("Make_Poison", Poison_interval);

    }

    // Update is called once per frame
    void Make()//敵の出るゴブリンを生成するメソッド
    {
        rand = Random.Range(min,max);
        Instantiate(Goblin, new Vector3(x_point[rand],y_point,z_point[rand]), Quaternion.Euler(0, -Enemy_rotate[rand], 0));
    }

    void Make_Apple()//強化アイテムであるリンゴを生成するメソッド
    {
        Instantiate(Apple, new Vector3(Apple_point[0], Apple_point[1], Apple_point[2]), this.transform.rotation);
    }
    void Make_Poison()//強化アイテム？である毒リンゴを生成するメソッド
    {
        Instantiate(Poison, new Vector3(Poison_point[0], Poison_point[1], Poison_point[2]), this.transform.rotation);
    }

    public static void upLevel(){//エネミーのレベルを上げるメソッド
        Enemy_level += 1;
    }
}
