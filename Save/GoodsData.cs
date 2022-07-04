using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsData : MonoBehaviour
{
    // item ScriptableObject에서 가져올 정보
    public ItemInformation item;// ScriptableObject
    public RawImage myGoodsImage;////상품 이미지
    public Text myGoodsName;//상품 이름
    public Text myGoodsPriceText;//상품 가격(보여주기 전용)

    //오브젝트
    public GameObject buyCanvas;
    public Button button;
    private void OnValidate()
    {
        button = GetComponent<Button>();
        myGoodsImage.texture = item.goodsImage;//상품 이미지
        myGoodsName.text = item.goodsName;//상품 이름
        if (item.price != 0)
            myGoodsPriceText.text = GetThousandCommaText(item.price).ToString();//보여주기 Text
        else
            myGoodsPriceText.text = "0";
    }
    private void Start()
    {
        button.onClick.AddListener(CanvasOn);
    }
    public void CanvasOn()
    {
        buyCanvas.GetComponent<GoodsBuyCanvas>().item = item;
        buyCanvas.SetActive(true);
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
}
