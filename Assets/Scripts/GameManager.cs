using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card_data> deck = new List<Card_data>();
    public List<Card_data> player_deck = new List<Card_data>();
    public List<Card_data> ai_deck = new List<Card_data>();
    public List<Card_data> player_hand = new List<Card_data>();
    public List<Card_data> ai_hand = new List<Card_data>();
    public List<Card_data> discard_pile = new List<Card_data>();
    [SerializeField] Card blank;
    [SerializeField] Canvas canvas;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        if (player_deck.Count > 0)
        {
            int NewCard = (int) RNG(0,player_deck.Count-1);
            player_hand.Add(player_deck[NewCard]);

            Card AddCard = Instantiate(blank,new(0,0,0),Quaternion.identity,canvas.transform);
            AddCard.data = player_deck[NewCard];
            AddCard.name = AddCard.data.card_name;
            player_deck.Remove(player_deck [NewCard]);
        }
       else
        {
            Shuffle();
        }
    }

    void Shuffle()
    {
        print("EVERYDAY IM SHUFFLING");

        for (int i = discard_pile.Count - 1; i > 0; i--)
        {
            int NewCard = (int)RNG(0,discard_pile.Count - 1);
            deck.Add(discard_pile[NewCard]);
            discard_pile.Remove(discard_pile[NewCard]);
        }
        Deal();
    }

    void AI_Turn()
    {

    }

    public float RNG(float min,float max)
    {
        return UnityEngine.Random.Range(min,max);
    }

    public void spacebar(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            Deal();
        }
    }

    
}
