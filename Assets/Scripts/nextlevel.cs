using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadBgm("Over", "Over");//BGMのセット
        Sound.LoadSe("click", "Title_C");//クリック音をセット
        Sound.PlayBgm("Over");//BGMの再生
    }

    // Update is called once per frame
public void Onclick2()
    {
        //int Enemy_level = Maker.getLevel();
        Maker.upLevel();

        Sound.StopBgm();//BGMのストップ
        Sound.PlaySe("click");//クリック音の再生
        SceneManager.LoadScene("CountDown");//カウントダウン画面に戻る
    }
}
