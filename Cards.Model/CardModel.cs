﻿using Cards.DAO;
using Cards.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Model
{
    public class CardModel // Recebe informações do banco de dados
    {
        public static int Insert(Card objTable)
        {
            return new CardDAO().Insert(objTable);
        }

        public List<Card> ListAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
