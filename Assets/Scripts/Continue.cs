using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Sound.LoadBgm("Over", "Over");//BGMのセット
        Sound.LoadSe("click", "Title_C");//クリック音をセット
        Sound.PlayBgm("Over");//BGMの再生
    }

    public void Onclick()
    {
        Sound.StopBgm();//BGMのストップ
        Sound.PlaySe("click");//クリック音の再生
        SceneManager.LoadScene("CountDown");//カウントダウン画面に戻る
    }
}
