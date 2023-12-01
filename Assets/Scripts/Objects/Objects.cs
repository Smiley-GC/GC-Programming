using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1
{
    public float health = 100;
    public float mana = 100.0f;
    public float armour = 1.0f;
    public float damage = 10.0f;
    public float movementSpeed = 2.0f;
    public int score = 0;
    public string name = "";
}

public class Character2
{
    public float health;
    public float mana;
    public float armour;
    public float damage;
    public float movementSpeed;
    public int score;
    public string name;
}

public class Objects : MonoBehaviour
{
    Character1 character1 = new Character1();
    Character2 character2 = new Character2();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(character1.health);
        Debug.Log(character1.mana);
        Debug.Log(character1.armour);
        Debug.Log(character1.damage);
        Debug.Log(character1.movementSpeed);
        Debug.Log(character1.score);
        Debug.Log(character1.name);

        Debug.Log(character2.health);
        Debug.Log(character2.mana);
        Debug.Log(character2.armour);
        Debug.Log(character2.damage);
        Debug.Log(character2.movementSpeed);
        Debug.Log(character2.score);
        Debug.Log(character2.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
