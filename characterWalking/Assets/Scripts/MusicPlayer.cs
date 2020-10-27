using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public void PlayMainTheme()
    {
        FindObjectOfType<AudioManager>().Play("FatPhonk");
    }
}
