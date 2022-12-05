using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunePathImage : MonoBehaviour
{
    Image image;
    Sprite sprite;
    [SerializeField] float alpha;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        image.sprite = sprite;
    }
    public void SetPatern(RuneList.Patern _patern)
	{
        Debug.Log("Rune/" + _patern.ToString());
        sprite = Resources.Load<Sprite>("Rune/"+_patern.ToString());
        if (sprite == null)
        {
            sprite = Resources.Load<Sprite>("Rune/" + RuneList.Patern.NotInitialized.ToString());
        }
        if (image != null)
        {
        image.sprite = sprite;
        }
    }
}
