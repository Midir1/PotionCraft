using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SiblingIndex : MonoBehaviour
{
    public bool Masked;
    private GameObject Mask;
    int Index;
    int MaskIndex;

    void Awake()
    {
        //Initialise the Sibling Index to 0
        Index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(Index);
        Mask = GameObject.Find("Room/Forground/Mask");
        MaskIndex = Mask.transform.GetSiblingIndex();
        Debug.Log("Object Index =" + Index);
        Debug.Log("Mask Index =" + MaskIndex);
    }

    void Update()
    {
        //Press this Button to increase the sibling index number of the GameObject
        if (Masked == false)
        {
            //Make sure the index number doesn't exceed the Sibling Index of Mask
            if (Index <= MaskIndex)
            {
                //Increase the Index Number
                Index = MaskIndex + 1;
                transform.SetSiblingIndex(Index);
                Debug.Log("Object Index =" + Index);
                Debug.Log("Mask Index =" + MaskIndex);
            }
        }

        if (Masked == true)
        {
            Index = 0;
            transform.SetSiblingIndex(Index);
            Debug.Log("Object Index =" + Index);
            Debug.Log("Mask Index =" + MaskIndex);
        }
    }
}