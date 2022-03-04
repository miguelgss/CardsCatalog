using Cards.DAO;
using Cards.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Model
{
    public class CardModel // Recebe informações do banco de dados via o DAO
    {
        public static int Insert(Card objTable)
        {
            return new CardDAO().Insert(objTable);
        }

        public List<Card> ListAllCards()
        {
            return new CardDAO().ListAllCards();
        }

        public static int Delete(Card objTable)
        {
            return new CardDAO().Delete(objTable);
        }

        public static int Update(Card objTable)
        {
            return new CardDAO().Update(objTable);
        }

        public static bool Search(Card objTable)
        {
            return new CardDAO().Search(objTable);
        }
    }
}
