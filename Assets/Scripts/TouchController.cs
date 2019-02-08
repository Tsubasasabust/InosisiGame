using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public GameObject Chara;//イノシシオブジェクト
    public GameObject particle;
    private Vector3 toushScreenPosition;//始点
    private Vector2 a;
    private Vector3 UsePosition;
    private float dx;
    private float dy;
    private float rad;
    private float ControllRad;
    private CharacterController characterController;
    private Animator animator;
    private float Speed;
    private RectTransform circle;
    private RectTransform circle2;
    //public GameObject image1;
    //public GameObject image2;
    [SerializeField] Image Image1;
    [SerializeField] Image Image2;
    private GameObject Apple_Image;
    private GameObject Poison_Image;


    [SerializeField] private float move_speed;
    [SerializeField] private float Run_speed;

    void Start()
    {
        
        Sound.LoadSe("bakuhatsu", "bakuhatsu");
        Sound.LoadBgm("Crear", "Crear");
        Sound.LoadBgm("Walk", "Walk");
        Sound.LoadBgm("Main", "Main_BGM");
        Sound.LoadSe("Apple", "Apple_Sound");
        Sound.LoadSe("Poison", "Poison_Sound");

        Sound.PlayBgm("Main");
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //Image1 = GetComponent<RectTransform>();

        //circle = GameObject.Find("取得したいImageオブジェクト").GetComponent<RectTransform>();
        //hoge = GameObject.Find("取得したいImageオブジェクト").GetComponent<RectTransform>();
        circle = GameObject.Find("Image1").GetComponent<RectTransform>();
        circle2 = GameObject.Find("Image2").GetComponent<RectTransform>();
        this.transform.localScale = new Vector3(2f, 2f, 2f);

        Apple_Image = GameObject.Find("Apple");
        Poison_Image = GameObject.Find("Poison");
        
        Apple_Image.SetActive(false);
        Poison_Image.SetActive(false);
    }

        // Update is called once per frame
        void Update()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Speed = 0;

            //toushScreenPosition = transform.InverseTransformPoint(Input.mousePosition);
            toushScreenPosition = Input.mousePosition;
            //Image1.localPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            circle2.localPosition = new Vector2(Input.mousePosition.x - 363f, Input.mousePosition.y - 158f);
            //Debug.Log(toushScreenPosition);
        }
        if (Input.GetMouseButton(0))
        {
            //circle.localPosition = new Vector3(UsePosition.x, UsePosition.z);
            UsePosition = Input.mousePosition;
            Debug.Log(Input.mousePosition);
            circle.localPosition = new Vector2(Input.mousePosition.x-363f, Input.mousePosition.y-158f);
            //circle.localPosition = new Vector2(UsePosition.x, UsePosition.y);
            dx = UsePosition.x - toushScreenPosition.x;
            dy = UsePosition.y - toushScreenPosition.y;
            rad = Mathf.Atan2(dy, dx);
            Speed = Mathf.Sqrt(Mathf.Pow(dx, 2) + Mathf.Pow(dy, 2));
            //Debug.Log(Speed);
            ControllRad = rad * Mathf.Rad2Deg;
     

            expart(ControllRad);
            circle.transform.eulerAngles = new Vector3(0,0,ControllRad);
            //transform.eulerAngles = new Vector3(0, -ControllRad, 0);
           /* if(ControllRad <= 90)
            {
                transform.eulerAngles += new Vector3(0, 2, 0);
            }else if (ControllRad >= 91)
            {
                transform.eulerAngles -= new Vector3(0, 2, 0);
            }*/

            //transform.eulerAngles = new Vector3(0, -ControllRad / move_speed, 0);//contorollradが＋なら右みたいな処理を畏怖分で書いたほうがよろし
            Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);
            if (Speed <= 70.0)
            {
                //Sound.StopBgm();
                this.gameObject.transform.position -= velocity * Time.deltaTime;
                animator.SetFloat("Speed", 2f);
                //Sound.PlayBgm("Walk");
            }
            else if (Speed >= 70.1)
            {
                //Sound.StopBgm();
                this.gameObject.transform.position -= velocity * Time.deltaTime * Run_speed;
                animator.SetFloat("Speed", 4f);
                //Sound.PlayBgm( "Run");
            }

            //this.transform.position += new Vector3(0,0,move_speed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Sound.StopBgm();
            Speed = 0;
            animator.SetFloat("Speed", 0f);
        }

    }

    void expart(float ControllRad)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            foreach (ContactPoint point in collision.contacts)
            {
                //Debug.Log(point);
                {
                    Sound.PlaySe("bakuhatsu");
                    particle.transform.position = (Vector3)point.point;
                    Instantiate(particle, particle.transform.position, transform.rotation);
                    Destroy(collision.gameObject);
                }
            }
        }else if(collision.gameObject.tag == "red_apple")
        {
            Sound.PlaySe("Apple");
            Apple_Image.SetActive(true);
            this.transform.localScale = new Vector3(4f, 4f, 4f);
            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag == "poison_apple")
        {
            Sound.PlaySe("Poison");
            Poison_Image.SetActive(true);
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(collision.gameObject);

        }
    }
}
