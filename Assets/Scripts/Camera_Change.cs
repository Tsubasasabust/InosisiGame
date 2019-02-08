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
        MainCam = GameObject.Find("MainCamera");
        SubCam = GameObject.Find("SubCamera");

        SubCam.SetActive(false);
        Camera_State = "MainCam";
    }

    public void Camera()
    {
        if(Camera_State == "MainCam")
        {
            MainCam.SetActive(false);
            SubCam.SetActive(true);
            Camera_State = "SabCam";
        }
        else
        {
            MainCam.SetActive(true);
            SubCam.SetActive(false);
            Camera_State = "MainCam";
        }
    }

    /*void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (MainCam.activeSelf)
            {
                MainCam.SetActive(false);
                SubCam.SetActive(true);
            }
            else
            {
                MainCam.SetActive(true);
                SubCam.SetActive(false);
            }
        }
    }*/
}
