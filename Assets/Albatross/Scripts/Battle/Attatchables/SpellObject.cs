/* Project Albatross 
 * Prepared by Eddie Fulton
 * Unpublished/Unfinished
 * Purpose: Loads the Scritable Objects for use in Battle.
 * Status: Member: Testing 
 */

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

        [SerializeField]
        SpellManager sm;

        [SerializeField]
        TargetType tt;
        EffectType et;

        public int cost; 

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

            cost = spell.cost;

           
            tt = spell.Ability.TargetType;
            et = spell.Ability.effect.getEffectType();

            attatchedImage = GetComponent<Image>();
            attatchedImage.sprite = cardImage;

            sm = FindObjectOfType<SpellManager>();
            gm = FindObjectOfType<BattleManager>();
            dm = FindObjectOfType<DeckManager>();
        }
        void Update()
        {
            sm = FindObjectOfType<SpellManager>();
            gm = FindObjectOfType<BattleManager>();
            dm = FindObjectOfType<DeckManager>();
            attatchedImage = GetComponent<Image>();
            attatchedImage.sprite = cardImage;
        }
        public TargetType getTargetType()
        {
            return tt;
        }

        public void OnPointerClick(PointerEventData pe)
        {
            sm.setSpell(this);
            SpellPreviewPanel spp = FindObjectOfType<SpellPreviewPanel>();
            spp.setPreviewPanel(spell.artwork, spell.description);

            if (pe.clickCount > 1)
            {
                Cast();
            }
        }

        public SpellObject Select()
        {
            return this;
        }

        public void Cast()
        {
            sm.setSpell(this);
            TurnManager tm = FindObjectOfType<TurnManager>();

            switch (tt)
            {
                case TargetType.Self:
                    spell.Ability.Activate();
                    Destroy(gameObject);
                    tm.EndTurn();
                    break;
                case TargetType.AllyMonster:
                    break;
                case TargetType.AllySpell:
                    break;
                case TargetType.EnemySpell:
                    break;
                case TargetType.EnemyMonster:
                    break;
                case TargetType.NoTarget:
                    spell.Ability.Activate();
                    Destroy(gameObject);
                    tm.EndTurn();
                    break;
            }
        }

        public void CastToTarget(MonsterObject target)
        {
            spell.Ability.Activate(target);
        }

        public void CastToTarget(SpellObject target)
        {
            spell.Ability.Activate(target);
        }
    }
}