using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.Base.Name;
        levelText.text = "Lvl " + pokemon.Level;
        hpBar.SetHp((float)pokemon.HP / pokemon.MaxHP);
    }

    public IEnumerator UpdateHp()
    {
        yield return hpBar.SetHpSmooth((float)_pokemon.HP / _pokemon.MaxHP);
    }
}
