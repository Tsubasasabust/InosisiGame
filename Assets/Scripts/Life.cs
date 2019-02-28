using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private int Life_Count = 3;
    public GameObject[] Life_image;
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadSe("Damage", "dameg");//ダメージ音のセット
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player")//敵とぶつかったときに行う処理..以外ではなく指定するべきだった
        {
            Sound.PlaySe("Damage");//ダメージ音の再生
            Life_Count -= 1;//ライフを下げる
            Life_image[Life_Count].SetActive(false);//ライフにイマージを一つ消す
            if (Life_Count == 0)//ライフがすべて消えたときゲームオーバー
            {
                SceneManager.LoadScene("Inosisi_Over");
            }
            
        }
    }

}
