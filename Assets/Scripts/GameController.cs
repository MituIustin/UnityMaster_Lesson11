using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int gold;

    private AudioSource myAudio;
    public bool audioIsPlay = false;
    public bool audioChanged = false;

    public int Gold{ get { return gold; } set { gold = value; } }
    public Text goldTexg;

    private void Awake()
    {
        Gold = 500;
        myAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(GetMoney());
    }

    private void Update()
    {
        if (audioIsPlay && audioChanged)
        {
            myAudio.Play();
            audioChanged = false;
        }
        if (!audioIsPlay && audioChanged)
        {
            myAudio.Stop();
            audioChanged = false;
        }

        goldTexg.text = $"Gold: {Gold}";
    }

    IEnumerator GetMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Gold += 100;
        }
    }
}
