using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GoodsBuyCanvas : MonoBehaviour
{
    // Item 버튼에서 받아온 Goods 아이템 정보
    public ItemInformation item;
    // 정보를 받아서 보여줄 변수
    public RawImage goodsImage;
    public Text goodsName;
    public Text goodsPriceText;
    //phoneNumber 입력UI 정보변수
    public InputField phoneNumber;
    public int phoneNumberInt;
    // 상품 구매 완료UI 정보변수
    public GameObject purchaseRequestCanvas;
    public GameObject purchaseCompleted_Canvas;
    public Text purchaseCompleted_Text;
    // 상품 구매 실패UI
    public GameObject inputFailed_Number;
    public GameObject inputFailed_Money;
    private void OnEnable()
    {
        goodsImage.texture = item.goodsImage;
        goodsName.text = item.goodsName;
        if (item.price != 0)
            goodsPriceText.text = GetThousandCommaText(item.price).ToString();
        else
            goodsPriceText.text = "0";
        Initialization();
    }
    public void Goods()
    {
        if (phoneNumber.text != "")
            phoneNumberInt = int.Parse(phoneNumber.text);
        // 구매
        if (PointScore.instance.scoreValue >= item.price && phoneNumber.text.Length == 8)
        {
            if (!inputFailed_Number.activeInHierarchy && !inputFailed_Money.activeInHierarchy)
            {
                purchaseRequestCanvas.SetActive(false);
                purchaseCompleted_Canvas.SetActive(true);
                purchaseCompleted_Text.text = $"{PhotonNetwork.NickName}님,{GetPhoneNumberText(phoneNumberInt)}번호로 아이템을 구매 했습니다";
                PointScore.instance.PointDown(item.price);
                //구매 성공
            }
        }
        else if (phoneNumber.text.Length != 8)
            inputFailed_Number.SetActive(true);
           //번호이상으로 실패
        else
            inputFailed_Money.SetActive(true);
           //돈 부족으로 실패
    }
    public void No()
    {
        gameObject.SetActive(false);
    }
    public void InputFailedCanvasOff()
    {
        phoneNumber.text = "";
        inputFailed_Number.SetActive(false);
        inputFailed_Money.SetActive(false);
    }
    // 초기화
    public void Initialization()
    {
        phoneNumber.text = "";
        purchaseRequestCanvas.SetActive(true);
        purchaseCompleted_Canvas.SetActive(false);
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
    public string GetPhoneNumberText(int data)
    {
        return string.Format("{0:010-####-####}", data);
    }
}
