using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


namespace Albatross
{
    [CommandInfo("GameState", "Battle Scene", "Transitions to battle Scene using Game Manager Method")]
    [AddComponentMenu("")]
    public class Gamestate : Command
    {

        public string BattleScene; 

        public override void OnEnter()
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.ToBattleScene(BattleScene);

            Continue();
        }
    }
}