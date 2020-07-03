using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite fullHeart;
    public Sprite halfHeart;

    private void Start()
    {
        sr.sprite = fullHeart;
    }
    public void CutHeart()
    {
        sr.sprite = halfHeart;
    }
    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
