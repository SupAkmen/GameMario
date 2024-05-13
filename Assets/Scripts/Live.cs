using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Live : MonoBehaviour
{
    public int liveCounterStart = 3;
    public TextMeshProUGUI liveCounterText;
    // Start is called before the first frame update
    void Start()
    {
        liveCounterText.text = liveCounterStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        liveCounterStart = GameManager.Instance.lives;
        liveCounterText.text = "Live: " + liveCounterStart.ToString();
    }
}
