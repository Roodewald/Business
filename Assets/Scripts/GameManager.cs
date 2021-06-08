using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    float money = 3000;
    float rubies;

    [SerializeField] WindowGraph windowGraph;
    [SerializeField] TMP_Text textMoney;

    private void Awake()
    {
        
    }

    private void Update()
    {
        textMoney.text = money.ToString();
    }
}
