using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// A continer class for Spell Scriptable Objects to be used in the Unity Engine
/// Used in the Deck creation and Battles
/// </summary>
namespace Albatross
{
    public class SpellObject : MonoBehaviour, IPointerClickHandler
    {
        BattleManager gm;

        [SerializeField]
        SpellManager sm;

        [SerializeField]
        TargetType tt;
        [SerializeField]
        EffectType et;

        public int cost;
        public TypeElement element; 
        public SpellCard Spell;

        public string description;
        public Sprite cardImage;

        Image attatchedImage;

        void Start()
        {
            name = Spell.name;
            description = Spell.description;
            cardImage = Spell.artwork;
            cost = Spell.cost;

            attatchedImage = GetComponent<Image>();
            attatchedImage.sprite = cardImage;

            sm = FindObjectOfType<SpellManager>();
            gm = FindObjectOfType<BattleManager>();
        }

        public TargetType GetTargetType()
        {
            return tt;
        }

        public void OnPointerClick(PointerEventData pe)
        {

            sm.setSpell(this);
            SpellPreviewPanel spp = FindObjectOfType<SpellPreviewPanel>();
            spp.setPreviewPanel(Spell.artwork, Spell.description);

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
                    Destroy(gameObject);
                    tm.EndTurn();
                    break;
                case TargetType.NoTarget:
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
        }

        public void CastToTarget(SpellObject target)
        {
        }

    }
}