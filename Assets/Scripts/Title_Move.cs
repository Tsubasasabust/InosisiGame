using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Move : MonoBehaviour
{
    //public GameObject TapEffects;

    //public GameObject canvas;
    public GameObject Tap;
    private bool TapState;
    private int Count;

    void Start()
    {
        
        Sound.LoadBgm("1", "Title_BGM");
        Sound.LoadSe("5", "Title_C");
        Sound.PlayBgm("1");
        Tap.SetActive(false);
        StartCoroutine(TapCoroutine());
        TapState = false;
        Count = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           //Vector3 toushScreenPosition = Input.mousePosition;
            //GameObject prefab = (GameObject)Instantiate(TapEffects, toushScreenPosition, Quaternion.identity);
            //prefab.transform.SetParent(canvas.transform, false);
            //prefab.transform.position = new Vector3(toushScreenPosition.x, toushScreenPosition.y, toushScreenPosition.z);
            //Sound.PlaySe("5");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Sound.StopBgm();
            Sound.PlaySe("5");
            StartCoroutine(Scene());
            //Sound.PlaySe("5");
            /*yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("CountDown");*/
            /*Sound.StopBgm();
            Sound.LoadBgm("2", "2_senryak");
            Sound.PlayBgm("2");*/
        }
        /*if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("resultscene");
            Sound.StopBgm();
        }*/
    }
    private IEnumerator TapCoroutine()
    {
        while (true)
        {

            Tap.SetActive(true);
            Debug.Log("Ok");
            yield return new WaitForSeconds(1.0f);
            Tap.SetActive(false);
            Count += 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator Scene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("CountDown");
    }
}
