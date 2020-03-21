using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject Canvas;

    public Image LobbyImg;

    public Button StartGame;

    public Button TestGamePlay;

    public Button PlayGamePlay;

    public Button StopTest;


    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        StartGame.gameObject.SetActive(false);
        TestGamePlay.gameObject.SetActive(false);
        PlayGamePlay.gameObject.SetActive(false);
        StopTest.gameObject.SetActive(false);
    }
}
