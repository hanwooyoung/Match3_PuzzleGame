using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeartShopPopup : MonoBehaviour {

    public CUILobby UILobby = null;
    public GameObject BuyPanel = null;
   

    // Use this for initialization
    void Start () {


    }
	


    public void OnClickBuyHeart()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        if (UILobby.UserData.Heart < 5)
        {
            if (UILobby.UserData.Coin >= 300)
            {
                Debug.Log("구매");
                BuyPanel.SetActive(true);
                UILobby.UserData.Heart++;
                UILobby.UserData.Coin -= 300;
                UILobby.TotalCoin.text = UILobby.UserData.Coin.ToString();
            }
            else
            {
                Debug.Log("돈부족");
            }
        }
        else
        {
            Debug.Log("하트가 꽉차있습니다.");
        }
    }

    public void OnClickBuyPanelClose()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        BuyPanel.SetActive(false);
    }

    public void OnClickclosePopup()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        this.gameObject.SetActive(false);
    }

    public void SetUILobby(CUILobby tUILobby)
    {
        UILobby = tUILobby;
    }
}
