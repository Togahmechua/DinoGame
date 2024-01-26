using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CoinMNG : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public Canvas canvas;
    public GameObject snake;
    public Image NotEnoughMoney;
    private float coin;

    private void Update()
    {
        coinText.text = "Coin : " + coin;    
    }

    public void Coin()
    {
        coin += 1;
    }

    public void InputCoin()
    {
        if (coin > 0)
        {
            coin --;
            snake.SetActive(true);
            canvas.gameObject.SetActive(false);
        }
        else
        {
            NotEnoughMoney.gameObject.SetActive(true);
        }
    }
}
