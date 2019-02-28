using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private float totalTime = 60;
    private int seconds;
    void Update()
    {
        totalTime -= Time.deltaTime;//時間を減らしていく
        seconds = (int)totalTime;//int型に変換
        timerText.text = seconds.ToString();//text用にstringに変換
        if(seconds == 0)//Enemy_levelによってクリアか判定する
        {
            int Enemy_level = Maker.getLevel();
            if(Enemy_level == 2){
            SceneManager.LoadScene("Inosisi_Crear");//クリア画面に遷移
            }else{
            SceneManager.LoadScene("Inosisi_NextLevel");//クリア画面に遷移
            }
        }
    }
}
