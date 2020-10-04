using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController pController;
    [SerializeField] BattleSystem bSystem;
    [SerializeField] Camera mainCamera;

    GameState state;

    private void Start()
    {
        pController.OnEncountered += StartBattle;
        bSystem.OnBattleOver += EndBattle;
    }

    private void EndBattle(bool obj)
    {
        state = GameState.FreeRoam;
        bSystem.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }

    private void StartBattle()
    {
        state = GameState.Battle;
        bSystem.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);

        var playerParty = pController.GetComponent<PokemonParty>();
        var wildPokemon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();

        bSystem.StartBattle(playerParty,wildPokemon);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            pController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            bSystem.HandleUpdate();
        }
    }
}
