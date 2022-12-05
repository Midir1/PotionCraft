using JetBrains.Annotations;
using UnityEngine;

public class Fondu : MonoBehaviour
{
    [UsedImplicitly]
    public void DeleteAfterAnim()
    {
        Destroy(gameObject);
    }
}
