using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private const string coin500 = "com.StudioKroissant.WitchCraft.coins500";
    private const string buySkin = "com.StudioKroissant.WitchCraft.buySkin";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == coin500)
            Debug.Log("You've gained 500 coins");

        if (product.definition.id == buySkin)
            Debug.Log("You've gained the last skin");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because " + failureReason);
    }
}