using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float now_position_x;
    private float now_position_z;
    private float dx;
    private float dz;
    private float rad;
    private float ControllRad;
    [SerializeField] private float move_speed;



    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadSe("Samon", "Samon");
        Sound.PlaySe("Samon");
        now_position_x = this.gameObject.transform.position.x;
        now_position_z = this.gameObject.transform.position.z;

        dx = 0f - now_position_x;
        dz = 0f - now_position_z;
        rad = Mathf.Atan2(dz, dx);
        ControllRad = rad * Mathf.Rad2Deg;
        //this.transform.eulerAngles = new Vector3(0, ControllRad, 0);
        //Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Tanslate += new Vector3(1f, 0f, 0f);
        Vector3 velocity = this.gameObject.transform.rotation * new Vector3(0, 0, move_speed);
        this.gameObject.transform.position -= velocity * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log("Yes");
    }
}
