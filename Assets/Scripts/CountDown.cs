using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    
    [SerializeField]
    private GameObject One;
    [SerializeField]
    private GameObject Two;
    [SerializeField]
    private GameObject Three;
    [SerializeField]
    private GameObject Go;

    void Start()
    {
        Sound.LoadSe("Count", "Count");
        Sound.LoadSe("Game_Start", "Game_Start");

        One.SetActive(false);
        Two.SetActive(false);
        Three.SetActive(false);
        Go.SetActive(false);

        StartCoroutine(CountdownCoroutine());
    }


    IEnumerator CountdownCoroutine()
    {

        Sound.PlaySe("Count");
        Three.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        Sound.PlaySe("Count");
        Three.SetActive(false);
        Two.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        Sound.PlaySe("Count");
        Two.SetActive(false);
        One.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        Sound.PlaySe("Game_Start");
        One.SetActive(false);
        Go.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Inosisi_main");

    }
}
