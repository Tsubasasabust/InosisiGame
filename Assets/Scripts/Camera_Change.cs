using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject MainCam;
    private GameObject SubCam;
    private string Camera_State;

    void Start()
    {
        SubCam = GameObject.Find("MainCamera");//上からの視点
        MainCam = GameObject.Find("SubCamera");//下からの視点

        SubCam.SetActive(false);
        Camera_State = "MainCam";
    }

    public void Camera()//カメラの状態によって切り替える 画面上のボタンで切り替える
    {
        if(Camera_State == "MainCam")
        {
            MainCam.SetActive(false);
            SubCam.SetActive(true);
            Camera_State = "SabCam";
        }else
        {
            MainCam.SetActive(true);
            SubCam.SetActive(false);
            Camera_State = "MainCam";
        }
    }
}
