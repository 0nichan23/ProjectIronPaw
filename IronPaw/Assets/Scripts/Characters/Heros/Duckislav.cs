using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckislav : HeroProfile
{
    [SerializeField] private int _numberOfCardsToProccPassive = 4;
    [SerializeField] private int _passiveDamage = 6;


    

    public void DuckislavPassive(CardScriptableObject card)
    {
        if (_character.Controller.TurnTracker.NumberOfCardsPlayed == _numberOfCardsToProccPassive)
        {
            AudioManager.Instance.Play(AudioManager.Instance.SfxClips[9]);
            List<Character> enemies = new List<Character>();
            foreach (var enemy in EnemyWrapper.Instance.EnemyController.ControllerChracters)
            {
                if(enemy.CurrentHP > 0)
                {
                    enemies.Add(enemy);
                    Debug.Log(enemy.CharacterName);
                }
            }
            Character randomEnemy = enemies[new System.Random().Next(0, enemies.Count)];
            randomEnemy.TakeDmg(new Damage(_passiveDamage , _character, false));
            _character.PopupManager.AddMessage("Passive", FontMaterialManager.Instance.TextFontMaterial);
        }
        
    }

    public override void SubscribePassive()
    {
        _character.Controller.OnPlayCard += DuckislavPassive;
    }

    public override void UnSubscribePassive()
    {
        _character.Controller.OnPlayCard -= DuckislavPassive;
    }

    public override void Ultimate()
    {
        _character.Animator.SetTrigger("Ult");
        AudioManager.Instance.Play(AudioManager.Instance.UltClips[0]);
        _character.MaxAp++;
        _character.CurrentAp++;
        _character.OnStartTurn += DuckislavBuff;
    }

    private void DuckislavBuff()
    {
        _character.Deck.Draw();
    }
    
}
