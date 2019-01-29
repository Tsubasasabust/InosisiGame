using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker : MonoBehaviour
{
    //private int[,] x_point;
    //private int[,] z_point;
    private float[] x_point;
    private float y_point = 5f;
    private float[] z_point;
    public GameObject Yaku;
    private int rand;
    private int min = 0;
    private int max = 9;

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
        x_point = new float[] { -80f, 0f, 80, -80f, 0f, 80f, -80f, 0f, 80f };
        z_point = new float[] { 80f, 80f, 80f, 0f, 0f, 0f, -80f, -80f, -80f };
        InvokeRepeating("Make", 1f,5f);
    }

    // Update is called once per frame
    void Make()
    {
        rand = Random.Range(min,max);
        Instantiate(Yaku, new Vector3(x_point[rand],y_point,z_point[rand]), transform.rotation);
        Debug.Log("Hello");
    }
}
