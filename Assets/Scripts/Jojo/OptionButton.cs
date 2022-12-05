using JetBrains.Annotations;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    [UsedImplicitly]
    public void EnableDisable()
    {
        button.SetActive(!button.activeSelf);
    }
}
