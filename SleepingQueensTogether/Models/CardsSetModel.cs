using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.Models
{
    public abstract class CardsSetModel
    {
        protected readonly List<Card> cardsDeck;

        public CardsSetModel() { cardsDeck = []; }

        public bool SingleSelect { protected get; set; }

        public abstract void FillPackage();
        [Ignored]
        public int Count => cardsDeck.Count;
        
    }
}
