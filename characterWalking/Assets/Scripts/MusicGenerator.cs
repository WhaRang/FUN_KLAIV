using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGenerator : MonoBehaviour
{
    public static int RHYME_SIZE = 4;
    public static int FILL_ORDER = 4;
    public static int LINE_SIZE = 32;

    private static float BASS_FREQ = 0.5f;

    static bool[] hatLine = new bool[LINE_SIZE];
    static bool[] bassLine = new bool[LINE_SIZE];
    static bool[] snareLine = new bool[LINE_SIZE];

    private void Start()
    {
        generateBassLine();
        generateHatLine();
        generateSnareLine();
    }

    void generateBassLine()
    {
        int n = (LINE_SIZE / RHYME_SIZE) / FILL_ORDER;
        bool[] rhyme = generateBassRhyme();
        for (int i = 0; i < n; i++)
        {            
            bool[] fill = generateBassFill();
            for (int j = 0; j < FILL_ORDER - 1; j++)
            {
                for (int z = 0; z < RHYME_SIZE; z++)
                {
                    bassLine[j * RHYME_SIZE * (i + 1) + z] = rhyme[z];
                }
            }
            for (int z = 0; z < RHYME_SIZE; z++)
            {
                bassLine[((LINE_SIZE / n) * (i + 1)) - RHYME_SIZE + z] = rhyme[z];
            }
        }
    }
    void generateHatLine() { }
    void generateSnareLine() { }

    bool[] generateBassRhyme()
    {
        bool[] rhyme = new bool[RHYME_SIZE];
        int counter = 0;
        for (int i = 0; i < RHYME_SIZE; i++)
        {
            if (counter == RHYME_SIZE - 1)
            {
                break;
            }
            if (Random.value < BASS_FREQ)
            {
                counter++;
                rhyme[i] = true;
            }
            else
            {
                rhyme[i] = false;
            }
        }
        if (counter == 0)
        {
            rhyme[0] = true;
        }
        return rhyme;
    }

    bool[] generateBassFill()
    {
        return generateBassRhyme();
    }

    public static bool[] getBassLine()
    {
        return bassLine;
    }
}
