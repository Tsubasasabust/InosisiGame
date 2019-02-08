using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Sound.StopBgm();
        Sound.LoadBgm("Over", "Over");
        Sound.LoadSe("click", "Title_C");
        Sound.PlayBgm("Over");
     
    }

    public void Onclick()
    {
        Sound.StopBgm();
        Sound.PlaySe("click");
        SceneManager.LoadScene("CountDown");
    }
}
