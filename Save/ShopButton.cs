using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject shopCanvas;
    public Text pointText;
    
    public void ShopCanvasOn()
    {
        shopCanvas.SetActive(true);
    }
    public void ShopCanvasOff()
    {
        shopCanvas.SetActive(false);
    }
    public void Update()
    {
        if (PointScore.instance.scoreValue > 0)
            pointText.text = GetThousandCommaText(PointScore.instance.scoreValue).ToString();
        else
            pointText.text = "0";
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
}
