using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public float totalTime;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadBgm("Crear", "Crear");
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();
        if(seconds == 0)
        {
            Sound.PlayBgm("Crear");
            SceneManager.LoadScene("Inosisi_crear");
        }
    }
}
