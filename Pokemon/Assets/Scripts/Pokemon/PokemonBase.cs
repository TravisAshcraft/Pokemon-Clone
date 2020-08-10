using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon", menuName = "Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;


    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public PokemonType Type1
    {
        get { return type1; }
    }

    public PokemonType Type2
    {
        get { return type2; }
    }

    public int MaxHP
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpAttack
    {
        get { return spAttack; }
    }

    public int SpDefense
    {
        get { return spDefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }

}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;
    
    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Phsychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}

public class TypeChart
{
   static float[][] chart =
    {
        //                  Nor  Fir  Wat Ele Gra Ice Fig Poi Gro Fly Phs Bug Roc Gho Dra
       /*Nor*/ new float [] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,.5f, 0f, 1f  },
       /*Fir*/ new float [] { 1f,.5f,.5f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 2f,.5f, 1f, 1f  },
       /*Wat*/ new float [] { 1f, 2f,.5f, 1f,.5f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f, 1f,.5f  },
       /*Ele*/ new float [] { 1f, 1f, 2f,.5f,.5f, 1f, 1f, 1f, 0f, 2f, 1f, 1f, 1f, 1f,.5f  },
       /*Gra*/ new float [] { 1f,.5f, 2f, 1f,.5f, 1f, 1f,.5f, 2f,.5f, 1f, 1f, 2f, 1f,.5f  },
       /*Ice*/ new float [] { 1f,.5f,.5f, 1f, 2f, 1f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 2f  },
       /*Fig*/ new float [] { 2f, 1f, 1f, 1f, 1f, 2f, 1f,.5f, 1f,.5f,.5f,.5f, 2f, 0f, 1f  },
       /*Poi*/ new float [] { 1f, 1f, 1f, 1f, 2f, 1f, 1f,.5f,.5f, 1f, 1f, 1f,.5f,.5f, 1f  },
       /*Gro*/ new float [] { 1f, 2f, 1f, 2f,.5f, 1f, 1f, 2f, 1f, 0f, 1f,.5f, 2f, 1f, 1f  },
       /*Fly*/ new float [] { 1f, 1f, 1f,.5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, 2f,.5f, 1f, 1f  },
       /*Phs*/ new float [] { 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f, 1f,.5f, 1f, 1f, 1f, 1f  },
       /*Bug*/ new float [] { 1f,.5f, 1f, 1f, 2f, 1f,.5f,.5f, 1f,.5f, 2f, 1f, 1f,.5f, 1f  },
       /*Roc*/ new float [] { 1f, 2f, 1f, 1f, 1f, 2f,.5f, 1f,.5f, 2f, 1f, 2f, 1f, 1f, 1f  },
       /*Gho*/ new float [] { 0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f  },
       /*Dra*/ new float [] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f  },
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
        {
            return 1;
        }

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}
