using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

// Classes are passed "by-reference" by default
public class Character
{
    public float health = 100.0f;
    public float mana = 100.0f;
    public float armour = 1.0f;
    public float damage = 10.0f;
    public float movementSpeed = 2.0f;
    public int score = 0;
    public string name = "";
}

// Structures are passed "by-value" (copied) by default
public struct Test
{
    public int score;
}

public class Objects : MonoBehaviour
{
    void PrintStats(Character c)
    {
        Debug.Log(c.health);
        Debug.Log(c.mana);
        Debug.Log(c.armour);
        Debug.Log(c.damage);
        Debug.Log(c.movementSpeed);
        Debug.Log(c.score);
        Debug.Log(c.name);
    }

    void SetScore(Character character)
    {
        character.score = 69;
    }

    void SetScore(Test test)
    {
        test.score = 69;
    }

    void SetScore(ref Test test)
    {
        test.score = 69;
    }

    void Combat(Character player, Character ally, Character boss)
    {
        while (player.health > 0.0f && ally.health > 0.0f && boss.health > 0)
        {
            player.health -= boss.damage;
            ally.health -= boss.damage;
            boss.health -= player.damage;
            boss.health -= ally.damage;
        }
        if (boss.health > 0)
            Debug.Log(boss.name + " is victorious!");
        else
        {
            Debug.Log(player.name + " lives another day...");
            Debug.Log(ally.name + " lives another day...");
        }
    }

    Character player = new Character();
    Character ally = new Character();
    Character boss = new Character();

    // Start is called before the first frame update
    void Start()
    {
        player.name = "Justin";
        player.health = 125.0f;
        player.mana = 150.0f;
        player.damage *= 2.0f;

        ally.name = "Andrew";
        ally.health = 75.0f;
        ally.mana = 100.0f;
        ally.damage *= 2.0f;

        boss.name = "Joey";
        boss.health = 250.0f;
        boss.mana = 175.0f;

        //PrintStats(player);
        //PrintStats(ally);
        //PrintStats(boss);
        Combat(player, ally, boss);

        Test test = new Test();
        SetScore(test);     // Operates on a copy of test
        SetScore(ref test); // Operates on test
        SetScore(player);
        Debug.Log(player.score);
        Debug.Log(test.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
