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
    public bool open1 = true;
    public bool open2 = true;
    public bool open3 = true;
    public Vector3 slot1 = new(0,0,0);
    public Vector3 slot2 = new(0,0,0);
    public Vector3 slot3 = new(0,0,0);
    public Vector2 canvasCanas;

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
        canvasCanas = canvas.renderingDisplaySize;
    }

    void Deal()
    {
        for (int i = player_hand.Count; i <3; i++)
        {
            if (player_deck.Count<= 0)
            {
                Shuffle();
            }

            Vector3 position = new(0,0,0);
            int slot0 = 0;
            if (open1) {position = slot1; open1 = false; slot0 = 1;}
            else if(open2) {position = slot2; open2 = false; slot0 = 2;}
            else if(open3) {position = slot3; open3 = false; slot0 = 3;}

            int NewCard = (int) RNG(0,player_deck.Count-1);
            player_hand.Add(player_deck[NewCard]);

            Card AddCard = Instantiate(blank,position,Quaternion.identity,canvas.transform);
            AddCard.data = player_deck[NewCard];
            AddCard.name = AddCard.data.card_name;
            player_deck.Remove(player_deck [NewCard]);
            AddCard.slot0 = slot0;
            AddCard.transform.Translate(canvasCanas/2);
        }
    }

    void Shuffle()
    {
        print("EVERYDAY IM SHUFFLING");
        if (discard_pile.Count > 0)
        {
            for (int i = discard_pile.Count; i > 0; i--)
            {
                int NewCard = (int)RNG(0,discard_pile.Count - 1);
                player_deck.Add(discard_pile[NewCard]);
                discard_pile.Remove(discard_pile[NewCard]);
                print("Card back to deck");
            }
        }
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
