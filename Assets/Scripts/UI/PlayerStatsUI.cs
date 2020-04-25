using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Text health;
    public Text sanity;
    public Text stamina;
    public Text hunger;
    public Text thirst;

    void Update()
    {
        sanity.text = "Sanity: " + PlayerStats.getSanity().ToString();
        health.text = "Health: " + PlayerStats.getHealth().ToString();
        stamina.text = "Stamina: " + PlayerStats.getStamina().ToString();
        thirst.text = "Thirst: " +  PlayerStats.getThirst().ToString();
        hunger.text = "Hunger: " + PlayerStats.getHunger().ToString();
    }
}
