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
        Sound.LoadSe("Damage", "dameg");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player")
        {
            Sound.PlaySe("Damage");
            Life_Count -= 1;
            Life_image[Life_Count].SetActive(false);
            if (Life_Count == 0)
            {
                Sound.StopBgm();
                SceneManager.LoadScene("Inosisi_Over");
            }
            
        }
    }

}
