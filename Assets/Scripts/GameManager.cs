using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static uint coinsCollected;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is Null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);

        Physics2D.gravity = new Vector2(0, -60f);
    }

    public void AddCoins()
    {
        coinsCollected++;
    }

    public uint GetCoins()
    {
        return coinsCollected;
    }
}
