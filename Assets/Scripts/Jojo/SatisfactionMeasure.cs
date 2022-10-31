using UnityEngine;
using UnityEngine.UI;

//TODO increase/decrease clientspawn in function of satisfaction measure
public class SatisfactionMeasure : MonoBehaviour
{
    private Slider satisfactionSlider;

    private void Start()
    {
        satisfactionSlider = GetComponent<Slider>();
    }
}