using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellPreviewPanel : MonoBehaviour
{
    [SerializeField]
    Image SpellImage;
    [SerializeField]
    Text SpellDescription; 


    void Awake()
    {
        SpellImage = GetComponentInChildren<Image>();
        SpellDescription = GetComponentInChildren<Text>();
    }

    public void setPreviewPanel(Sprite spriteToPreveiw, string textToPreview)
    {
        SpellImage.sprite = spriteToPreveiw; SpellDescription.text = textToPreview; 
    }
}
