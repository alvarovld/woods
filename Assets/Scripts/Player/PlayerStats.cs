using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    static float health = 100;
    static float stamina = 100;
    static float sanity = 100;
    static float hunger = 100;
    static float thirst = 100;

    public static void setHealth(float h)
    {
        health = h;
    }

    public static void reduceHealth(float h)
    {
        health -= h;
    }

    public static float getHealth()
    {
        return health;
    }

    public static void setStamina(float s)
    {
        stamina = s;
    }

    public static float getStamina()
    {
        return stamina;
    }

    public static void setHunger(float h)
    {
        hunger = h;
    }

    public static float getHunger()
    {
        return hunger;
    }

    public static void setThirst(float t)
    {
        thirst = t;
    }

    public static float getThirst()
    {
        return thirst;
    }

    public static void setSanity(float s)
    {
        sanity = s;
    }

    public static float getSanity()
    {
        return sanity;
    }


}
