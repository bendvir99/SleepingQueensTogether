using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Card : CardModel
    {
        private static readonly string[][] cardsImage = {
        ["cakequeen.png","catqueen.png","dogqueen.png","heartqueen.png","ladybugqueen.png","moonqueen.png","pancakequeen.png","peacockqueen.png","rainbowqueen.png","rosequeen.png","starfishqueen.png","sunflowerqueen.png"],
        ["one.png","two.png","three.png","four.png","five.png","six.png","seven.png","eight.png","nine.png","ten.png"],
        ["kingone.png", "kingtwo.png", "kingthree.png", "kingfour.png", "kingfive.png", "kingsix.png", "kingseven.png", "knightone.png", "knighttwo.png", "knightthree.png", "knightfour.png", "dragon.png", "jester.png", "sleepingpotion.png", "wand.png"] };

        public Card()
        {
        }
        public Card(string type, int value)
        {
            Type = type;
            if (type == "Queen")
            {
                Image = cardsImage[0][value];
                QueenValue = value;
            }
            else if (type == "Number")
            {
                Image = cardsImage[1][value - 1];
                Value = value;
            }
            else if (type == "King")
            {
                Image = cardsImage[2][value - 1];
            }
            else if (type == "Knight")
            {
                Image = cardsImage[2][value + 6];
            }
            else if (type == "Dragon")
            {
                Image = cardsImage[2][value + 10];
            }
            else if (type == "Jester")
            {
                Image = cardsImage[2][value + 11];
            }
            else if (type == "SleepingPotion")
            {
                Image = cardsImage[2][value + 12];
            }
            else if (type == "Wand")
            {
                Image = cardsImage[2][value + 13];
            }
        }
    }
}
