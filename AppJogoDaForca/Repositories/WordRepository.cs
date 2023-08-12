﻿using AppJogoDaForca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoDaForca.Repositories
{
    public class WordRepository
    {
        private List<Word> _words;

        public WordRepository() 
        { 
            _words = new List<Word>();

            _words.Add(new Word("Nome", "Maria".ToUpper()));
            _words.Add(new Word("Vegetal", "Cenoura".ToUpper()));
            _words.Add(new Word("Fruta", "Abacate".ToUpper()));
            _words.Add(new Word("Tempero", "Baiano".ToUpper()));
            _words.Add(new Word("Tempero", "Nordestino".ToUpper()));
        }

        public Word GetRandomWord()
        {
            Random rand = new Random();
            var number = rand.Next(0, _words.Count);

            return _words[number];
        }
    }
}
