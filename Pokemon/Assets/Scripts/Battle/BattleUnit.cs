using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit) // tells unity that if this is player set the back of the sprite
        {
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        }
        else //if not player then front sprite
        {
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        }
    }
}
