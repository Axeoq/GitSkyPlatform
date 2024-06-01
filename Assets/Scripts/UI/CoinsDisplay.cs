using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    private TMP_Text txtCoins;

    // Start is called before the first frame update
    void Start()
    {
        txtCoins = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txtCoins.text = GameManager.Instance.GetCoins().ToString();
    }
}
