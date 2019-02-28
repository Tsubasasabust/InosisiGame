using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Move : MonoBehaviour
{
    public GameObject Tap;//押してくださいの文字を入れる
    private int Count;

    void Start()
    {
        
        Sound.LoadBgm("Title", "Title_BGM");
        Sound.LoadSe("Title_Click", "Title_C");
        Sound.PlayBgm("Title");
        Tap.SetActive(false);
        StartCoroutine(TapCoroutine());
        Count = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Sound.StopBgm();//BGMstop
            Sound.PlaySe("Title_Click");//クリック音の再生
            StartCoroutine(Scene_Move());//レスポンスの気持ち良さ的には少しずらして呼び出したほうが良いためコルーチンを用いる
        }
    }
    private IEnumerator TapCoroutine()//タイトルのスタートボタンの表示を一秒ごとにする
    {
        while (true)
        {
            Tap.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            Tap.SetActive(false);
            Count += 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator Scene_Move()//呼び出すとシーンをカウントダウンに遷移する
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("CountDown");
    }
}
