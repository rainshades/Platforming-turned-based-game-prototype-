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

        void Start()
        {
            name = spell.name;
            description = spell.description;
            cardImage = spell.artwork;

            cost = spell.cost;

           
            tt = spell.SpellEffect.TargetType;
            et = spell.SpellEffect.effect.getEffectType();

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
                    spell.SpellEffect.Activate();
                    Destroy(gameObject);
                    tm.EndTurn();
                    break;
                case TargetType.NoTarget:
                    spell.SpellEffect.Activate();
                    Destroy(gameObject);
                    tm.EndTurn();
                    break;
                default:
                    Debug.LogError("This is not a nontargetted Spell");
                    break; 
            }
        }//NonTarget Cast

        public void CastToTarget(MonsterObject target)
        {
            spell.SpellEffect.Activate(target);
        }

        public void CastToTarget(SpellObject target)
        {
            spell.SpellEffect.Activate(target);
        }
    }
}