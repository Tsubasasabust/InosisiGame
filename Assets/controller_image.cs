using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_image : MonoBehaviour
{
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var canvas = this.GetComponent<Canvas>();
            var canvasRect = canvas.GetComponent<RectTransform>();

            Vector2 localpoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out localpoint);
            var item = Instantiate(itemPrefab);
            item.transform.SetParent(this.transform);
            item.GetComponent<RectTransform>().anchoredPosition = localpoint;
            //DoTweenUtil.UpToRectTransform(item);
        }
    }
}
