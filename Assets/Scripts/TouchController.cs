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


    [SerializeField] private float move_speed;
    [SerializeField] private float Run_speed;

    void Start(){
        Sound.LoadSe("bakuhatsu", "bakuhatsu");
        characterController = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();
        //Image1 = GetComponent<RectTransform>();

        //circle = GameObject.Find("取得したいImageオブジェクト").GetComponent<RectTransform>();
        //hoge = GameObject.Find("取得したいImageオブジェクト").GetComponent<RectTransform>();
        circle = GameObject.Find("Image1").GetComponent<RectTransform>();
        circle2 = GameObject.Find("Image2").GetComponent<RectTransform>();
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
            if(ControllRad <= 90)
            {
                transform.eulerAngles += new Vector3(0, 1, 0);//contorollradが＋なら右みたいな処理を畏怖分で書いたほうがよろし
            }else if (ControllRad >= 91)
            {
                transform.eulerAngles -= new Vector3(0, 1, 0);//contorollradが＋なら右みたいな処理を畏怖分で書いたほうがよろし
            }

            //transform.eulerAngles = new Vector3(0, -ControllRad / move_speed, 0);//contorollradが＋なら右みたいな処理を畏怖分で書いたほうがよろし
            Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);
            if (Speed <= 70.0)
            {
                this.gameObject.transform.position -= velocity * Time.deltaTime;
                animator.SetFloat("Speed", 2f);
            }
            else if (Speed >= 70.1)
            {
                this.gameObject.transform.position -= velocity * Time.deltaTime * Run_speed;
                animator.SetFloat("Speed", 4f);
            }

            //this.transform.position += new Vector3(0,0,move_speed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Speed = 0;
            animator.SetFloat("Speed", 0f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
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
        }
    }
}
