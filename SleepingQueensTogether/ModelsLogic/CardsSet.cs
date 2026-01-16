using SleepingQueensTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.ModelsLogic
{
    public class CardsSet : CardsSetModel
    {
        private readonly Random rnd;
        private Card selectedCard;
        private readonly Card emptyCard;

        public CardsSet(bool full) : base()
        {
            emptyCard = new Card();
            selectedCard = emptyCard;
            rnd = new Random();
            if (full)
                FillPackage();

        }
        public CardsSet() : base()
        {
            emptyCard = new Card();
            selectedCard = emptyCard;
            rnd = new Random();
        }

        public override void FillPackage()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cardsDeck.Add(new Card("Number", j + 1));
                }
            }
            for (int i = 0; i < 7; i++)
            {
                cardsDeck.Add(new Card("King", i + 1));
            }
            for (int i = 0; i < 4; i++)
            {
                cardsDeck.Add(new Card("Knight", i + 1));
            }
            for (int i = 0; i < 3; i++)
            {
                cardsDeck.Add(new Card("Dragon", 1));
            }
            for (int i = 0; i < 5; i++)
            {
                cardsDeck.Add(new Card("Jester", 1));
            }
            for (int i = 0; i < 4; i++)
            {
                cardsDeck.Add(new Card("SleepingPotion", 1));
            }
            for (int i = 0; i < 3; i++)
            {
                cardsDeck.Add(new Card("Wand", 1));
            }
        }

        public void Reset(bool full)
        {
            //cards.Clear();
            //if (full)
            //    FillPakage();
        }

        public Card Add(Card card)
        {
            card.Index = cardsDeck.Count;
            card.Margin = new Thickness(50 + 30 * cardsDeck.Count, 0, 0, 0);
            cardsDeck.Add(card);
            return card;
        }

        public Card TakeCard()
        {
            Card card = new();
            if (cardsDeck.Count > 0)
            {
                int index = rnd.Next(0, cardsDeck.Count);
                card = cardsDeck[index];
                cardsDeck.RemoveAt(index);
            }
            return card;
        }

        public void SelectCard(Card card)
        {
            if (SingleSelect)
                if (card.IsSelected)
                {
                    selectedCard = emptyCard;
                    card?.ToggleSelected();
                }
                else
                {
                    selectedCard?.ToggleSelected();
                    card.ToggleSelected();
                    selectedCard = card;
                }
            else
                card?.ToggleSelected();
        }

        public Card ThrowCard(Card comparedCard)
        {
            Card card = new();
            if (IsMatch(comparedCard))
            {
                card = Card.Copy(selectedCard);
                if (!selectedCard.IsEmpty)
                {
                    cardsDeck.Remove(selectedCard);
                    for (int i = selectedCard.Index; i < cardsDeck.Count; i++)
                    {
                        cardsDeck[i].Index = i;
                        cardsDeck[i].Margin = new Thickness(cardsDeck[i].Margin.Left - 30, 0, 0, 0);
                    }
                    selectedCard = emptyCard;
                }
            }
            return card;
        }
        public bool IsMatch(Card card)
        {
            bool match = false;
            if (!selectedCard.IsEmpty)
                match = card.Value == selectedCard.Value || card.Type == selectedCard.Type;
            return match;
        }
    }
}
