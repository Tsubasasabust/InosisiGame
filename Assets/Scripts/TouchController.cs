using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject Chara;
    private Vector3 toushScreenPosition;
    private Vector2 a;
    private Vector3 UsePosition;
    private float dx;
    private float dy;
    private float rad;
    private float ControllRad;
    private CharacterController characterController;
    private Animator animator;
    private float Speed;


    [SerializeField] private float move_speed;
    void Start(){
        characterController = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
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
            transform.eulerAngles = new Vector3(0, -ControllRad, 0);
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
        }
    }
}
