using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



namespace Albatross
{
    public class SpellObject : MonoBehaviour, IPointerClickHandler
    {
        BattleManager gm;
        DeckManager dm;
        SpellManager sm;

        TargetType tt;
        EffectType et;

        public SpellCard spell;

        public string description;
        public Sprite cardImage;

        Image attatchedImage;

        // Start is called before the first frame update
        void Start()
        {
            name = spell.name;
            description = spell.description;
            cardImage = spell.artwork;

            tt = spell.Ability.TargetType;
            et = spell.Ability.effect.getEffectType();

            attatchedImage = GetComponent<Image>();
            attatchedImage.sprite = cardImage;

            sm = FindObjectOfType<SpellManager>();
            gm = FindObjectOfType<BattleManager>();
            dm = FindObjectOfType<DeckManager>();
        }

        public TargetType getTargetType()
        {
            return tt;
        }

        public void OnPointerClick(PointerEventData pe)
        {
            sm.setSpell(this);
            TurnManager tm = FindObjectOfType<TurnManager>();
            if (tt == TargetType.Self || tt == TargetType.NoTarget)
            {
                if (tt == TargetType.Self) { CastToTarget(tm.getCurrentMonster()); }
                if (tt == TargetType.NoTarget) { CastToTarget(); }
            }
            else
            {
                BattleUi boi = FindObjectOfType<BattleUi>();
                tm.CanvasOn(boi.targetBox.gameObject);
            }
        }

        public SpellObject Select()
        {
            return this;
        }

        public void CastToTarget()
        {
            spell.Ability.Activate();
        }

        public void CastToTarget(MonsterObject target)
        {
            spell.Ability.Activate(target);
        }

        public void CastToTarget(SpellObject target)
        {

        }
    }
}