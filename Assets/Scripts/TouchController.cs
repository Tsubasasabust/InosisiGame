using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public GameObject particle;
    private Vector3 toushScreenPosition;//始点
    private Vector3 UsePosition;
    private float dx;
    private float dy;
    private float rad;
    private float ControllRad;
    private CharacterController characterController;
    private Animator animator;
    private float Point_length;
    private RectTransform circle;
    private RectTransform controll_image;
    private GameObject Apple_Image;
    private float Apple_Scale = 6f;
    private GameObject Poison_Image;
    private float Poison_Scale = 2f;

private float tapPos;

    [SerializeField] private float move_speed;
    [SerializeField] private float Run_speed;

    void Start()
    {     
        Sound.LoadSe("bakuhatsu", "bakuhatsu");//爆発する音声のセット
        Sound.LoadBgm("Main", "Main_BGM");//BGMのセット
        Sound.LoadSe("Apple", "Apple_Sound");//リンゴと当たった音声のセット
        Sound.LoadSe("Poison", "Poison_Sound");//毒リンゴと当たった音声のセット

        Sound.PlayBgm("Main");
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        circle = GameObject.Find("Image1").GetComponent<RectTransform>();
        controll_image = GameObject.Find("Image2").GetComponent<RectTransform>();
        this.transform.localScale = new Vector3(4f, 4f, 4f);

        Apple_Image = GameObject.Find("Apple");
        Poison_Image = GameObject.Find("Poison");
        
        Apple_Image.SetActive(false);
        Poison_Image.SetActive(false);

    }
        // Update is called once per frame
        void Update()
    {
        
        TouchMove();//タッチされた時の操作
    }

    void TouchMove()
    {
        if (Input.GetMouseButtonDown(0))//タッチしたとき
        {

            Point_length = 0;//最初のスピードは０にする

            toushScreenPosition = Input.mousePosition;//タッチしたポジションの入手
        }
        if (Input.GetMouseButton(0))//タッチされてる間
        {
            UsePosition = Input.mousePosition;//タッチしている間のポジションの入手
            dx = UsePosition.x - toushScreenPosition.x;
            dy = UsePosition.y - toushScreenPosition.y;
            rad = Mathf.Atan2(dy, dx);//二点間からradianを示す
            Point_length = Mathf.Sqrt(Mathf.Pow(dx, 2) + Mathf.Pow(dy, 2));//二点間の長さを速度にする。
            ControllRad = rad * Mathf.Rad2Deg;//二点間の角度
     

            Angle_work(ControllRad);//イノシシの向きの処理
            controll_image.transform.eulerAngles = new Vector3(0,0,ControllRad);//コントローラーの向きを変更する処理
            Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);//イノシシを前方へ動かす処理
            if (Point_length <= 70.0)//タッチした個所から指が離れていなければ歩きの速度とモーション
            {
                this.gameObject.transform.position -= velocity * Time.deltaTime;
                animator.SetFloat("Speed", 2f);
            }
            else if (Point_length >= 70.1)//タッチした箇所から指が離れているとき走りの動きとモーション
            {
                this.gameObject.transform.position -= velocity * Time.deltaTime * Run_speed;
                animator.SetFloat("Speed", 4f);
            }

        }
        if (Input.GetMouseButtonUp(0))//タッチが離れたとき、動きを止める
        {
            Point_length = 0;
            animator.SetFloat("Speed", 0f);
        }

    }

    void Angle_work(float ControllRad)//二点間の角度をそのままイノシシの向きにする
    {
        transform.eulerAngles = new Vector3(0, -ControllRad, 0);
    }

    void easy(float ControllRad)
    {
        if (ControllRad <= 90)
        {
            transform.eulerAngles += new Vector3(0, 2, 0);
        }
        else if (ControllRad >= 91)
        {
            transform.eulerAngles -= new Vector3(0, 2, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)//tagによって処理を変える
    {
        if (collision.gameObject.tag == "Enemy")//敵と当たった時
        {
            foreach (ContactPoint point in collision.contacts)//ぶつかったポジションの入手
            {
                {
                    Sound.PlaySe("bakuhatsu");
                    particle.transform.position = (Vector3)point.point;
                    Instantiate(particle, particle.transform.position, transform.rotation);//パーティクルの発生
                    Destroy(collision.gameObject);
                }
            }
        }else if(collision.gameObject.tag == "red_apple")//リンゴと当たった時
        {
            Sound.PlaySe("Apple");
            Apple_Image.SetActive(true);
            this.transform.localScale = new Vector3(Apple_Scale, Apple_Scale, Apple_Scale);
            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag == "poison_apple")//毒リンゴと当たった時
        {
            Sound.PlaySe("Poison");
            Poison_Image.SetActive(true);
            this.transform.localScale = new Vector3(Poison_Scale, Poison_Scale, Poison_Scale);
            Destroy(collision.gameObject);

        }
    }
}
