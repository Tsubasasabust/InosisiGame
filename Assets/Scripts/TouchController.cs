using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject Chara;//イノシシオブジェクト
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
    [SerializeField] private float move_speed;
    [SerializeField] private float Run_speed;
    void Start(){
        characterController = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();
        circle = GameObject.Find("Text").GetComponent<RectTransform>();
        circle2 = GameObject.Find("Text1").GetComponent<RectTransform>();
    }


    // Update is called once per frame
    void Update()
    {
        TouchMove();
        /*if(Input.GetMouseButtonDown(0)){
            Speed = 0;
            toushScreenPosition = Input.mousePosition;
            //Debug.Log(toushScreenPosition);
        }
        if(Input.GetMouseButton(0)){
            UsePosition = Input.mousePosition;
            dx = UsePosition.x - toushScreenPosition.x;
            dy = UsePosition.y - toushScreenPosition.y;
            rad = Mathf.Atan2(dy, dx);
            Speed = Mathf.Sqrt(Mathf.Pow(dx,2) + Mathf.Pow(dy,2));
            Debug.Log(Speed);
            ControllRad = rad * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, -ControllRad/move_speed, 0);
            Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);
            if(Speed <= 50.0){
                this.gameObject.transform.position -= velocity * Time.deltaTime;
                animator.SetFloat("Speed",2f);
            }else if(Speed >= 50.1){
            this.gameObject.transform.position -= velocity * Time.deltaTime * 4;
            animator.SetFloat("Speed",4f);
            }
            
            //this.transform.position += new Vector3(0,0,move_speed);
        }
        if(Input.GetMouseButtonUp(0)){
            Speed = 0;
            animator.SetFloat("Speed",0f);
        }*/
    }
    void TouchMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Speed = 0;
            toushScreenPosition = Input.mousePosition;
            circle2.localPosition = new Vector3(toushScreenPosition.x, toushScreenPosition.y);
            //Debug.Log(toushScreenPosition);
        }
        if (Input.GetMouseButton(0))
        {
            //circle.localPosition = new Vector3(UsePosition.x, UsePosition.z);
            UsePosition = Input.mousePosition;
            circle.localPosition = new Vector3(UsePosition.x, UsePosition.y);
            dx = UsePosition.x - toushScreenPosition.x;
            dy = UsePosition.y - toushScreenPosition.y;
            rad = Mathf.Atan2(dy, dx);
            Speed = Mathf.Sqrt(Mathf.Pow(dx, 2) + Mathf.Pow(dy, 2));
            Debug.Log(Speed);
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
}
