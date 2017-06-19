using System;
using UnityEngine;
using UnityEngine.Purchasing;


public class InAppPurchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;

    #region 상품ID
    // 상품ID는 구글 개발자 콘솔에 등록한 상품ID와 동일하게 해주세요.
    public const string ProductIDtest = "test";
    public const string productId1 = "rcoin";
    public const string productId2 = "mcoin";
    public const string productId3 = "lcoin";
    #endregion
    CUserData UserData = null;

    void Start()
    {
        UserData = new CUserData();
        InitializePurchasing();
    }

    private bool IsInitialized()
    {
        return (storeController != null && extensionProvider != null);
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
            return;

        var module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        builder.AddProduct(productId1, ProductType.Consumable, new IDs
        {
            { productId1, AppleAppStore.Name },
            { productId1, GooglePlay.Name },
        });

        builder.AddProduct(productId2, ProductType.Consumable, new IDs
        {
            { productId2, AppleAppStore.Name },
            { productId2, GooglePlay.Name }, }
        );

        builder.AddProduct(productId3, ProductType.Consumable, new IDs
        {
            { productId3, AppleAppStore.Name },
            { productId3, GooglePlay.Name },
        });


        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string productId)
    {
        try
        {
            if (IsInitialized())
            {
                Product p = storeController.products.WithID(productId);

                if (p != null && p.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", p.definition.id));
                    storeController.InitiatePurchase(p);
                }
                else
                {
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        catch (Exception e)
        {
            Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
        }
    }

    public void RestorePurchase()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions
                (
                    (result) => { Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore."); }
                );
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController sc, IExtensionProvider ep)
    {
        Debug.Log("OnInitialized : PASS");

        storeController = sc;
        extensionProvider = ep;
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + reason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

        switch (args.purchasedProduct.definition.id)
        {
            case ProductIDtest:
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                break;
            case productId1:

                //RCoin;
                UserData.Coin += 1000;
                break;

            case productId2:

                //MCoin;
                UserData.Coin += 5000;

                break;

            case productId3:

                //LCoin;
                UserData.Coin += 20000;

                break;

        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    public void BuyTestProduct()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        BuyProductID(ProductIDtest);
    }

    public void OnclickBuyRCoinBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();

        BuyProductID(productId1);
    }
    public void OnclickBuyMCoinBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();

        BuyProductID(productId2);
    }
    public void OnclickBuyLCoinBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();

        BuyProductID(productId3);
    }

    public void OnclickGetOutBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();

        this.gameObject.SetActive(false);
    }
}
