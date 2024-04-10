using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
public static int numberOfCoins;
public TextMeshProUGUI numberOfCoinsText;
public static int currentHealth = 100;
public Slider healthBar;
public static bool gameOver;
// Start is called before the first frame update
void Start()
{
numberOfCoins = 0;
gameOver = false;
}
// Update is called once per frame

void Update()
{
//Display number of coins
numberOfCoinsText.text = "Monedas:" + numberOfCoins;
//Update the slider value
healthBar.value = currentHealth;
//Game over
if(currentHealth < 0)
{
gameOver= true;
}
}
}