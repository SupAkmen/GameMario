using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinStart = 0;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coinStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinStart = GameManager.Instance.coins;
        coinText.text = "x" + coinStart.ToString();
    }
}
