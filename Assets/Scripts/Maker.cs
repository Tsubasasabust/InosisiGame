using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker : MonoBehaviour
{
    //private int[,] x_point;
    //private int[,] z_point;
    private float[] x_point;
    private float y_point = 2f;
    private float[] z_point;
    public GameObject Yaku;
    public GameObject Apple;
    public GameObject Poison;
    private int rand;
    private int min = 0;
    private int max = 8;
    private float[] enemy_rotate;
    private float[] Apple_point;
    private float[] Poison_point;
 


    // Start is called before the first frame update
    void Start()
    {
        /*x_point = new int[,] {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8}
        };*/
        /*z_point = new int[,] {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8}
        };*/
        x_point = new float[] { -80f, 0f, 80, -80f, 80f, -80f, 0f, 80f };//原点はない
        z_point = new float[] { 80f, 80f, 80f, 0f, 0f, -80f, -80f, -80f };
        enemy_rotate = new float[] { 45f, 0f, -45f, 90f, -90f, 135f, 180f, -135f };
        Apple_point = new float[] { 80f, 5f, 50f };
        Poison_point = new float[] { -80f, 5f, 50f };

        InvokeRepeating("Make", 1f,5f);
        Invoke("Make_Apple", 20f);
        Invoke("Make_Poison", 40f);

    }

    // Update is called once per frame
    void Make()
    {
        rand = Random.Range(min,max);
        Instantiate(Yaku, new Vector3(x_point[rand],y_point,z_point[rand]), Quaternion.Euler(0, -enemy_rotate[rand], 0));
        //Debug.Log("Hello");
    }

    void Make_Apple()
    {
        Debug.Log("Apple");
        Instantiate(Apple, new Vector3(Apple_point[0], Apple_point[1], Apple_point[2]), this.transform.rotation);
    }
    void Make_Poison()
    {
        Debug.Log("PoisonApple");
        Instantiate(Poison, new Vector3(Poison_point[0], Poison_point[1], Poison_point[2]), this.transform.rotation);
    }
}
