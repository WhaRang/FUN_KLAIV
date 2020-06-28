using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class spriteChanger : MonoBehaviour
{
    public Image sourceImage;
    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    public void setPressedSprite()
    {
        sourceImage.sprite = pressedSprite;
    }

    public void setUnpressedSprite()
    {
        sourceImage.sprite = unpressedSprite;
    }
}
