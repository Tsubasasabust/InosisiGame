using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float move_speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadSe("Samon", "Samon");//登場時の音声のセット
        Sound.PlaySe("Samon");//登場時の音声の再生
    }

    // Update is called once per frame
    void Update()//登場された向きからまっすぐ動かす。
    {
        Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);
        this.gameObject.transform.position -= velocity * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)//ぶつかったときの処理で自身を消滅させる
    {
        Destroy(gameObject);
    }
}
