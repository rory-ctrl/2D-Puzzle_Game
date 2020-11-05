using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues
{
    public static bool shouldPlay = false;

    public static int score {get; set;}
    public static int respawns {get; set;}

    public static int playerHealth = 100;
    public static float playerTime = 100;

    public static bool hasGun {get; set;}

    public static void setPlayerHealth(int health){
        playerHealth = health;
    }

    public static int getPlayerHealth(){
        return playerHealth;
    }

    public static void setPlayerTime(float time){
        playerTime = time;
    }

    public static float getPlayerTime(){
        return playerTime;
    }
}
