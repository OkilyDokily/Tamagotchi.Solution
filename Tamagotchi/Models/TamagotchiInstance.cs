using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    public class TamagotchiInstance
    {
        public string Name {get;set;}
        public int Id {get;}
     
        public int Food{get;set;}
      
        public int Attention{get;set;}
      
        public int Rest{get;set;}

        
        public void IncreaseFood()
        {
            Food = (Food >= 10) ? 10 : Food + 1;
        }

        public void IncreaseAttention()
        {
            Attention = (Attention >= 10) ? 10 : Attention + 1;
        }

        public void IncreaseRest()
        {
            Rest = (Rest >= 10) ? 10 : Rest + 1;
        }

        public bool IsDead()
        {
            return Food < 0 || Attention < 0 || Rest < 0;
        }

        private static List<TamagotchiInstance> _all = new List<TamagotchiInstance>();

        public TamagotchiInstance(string name)
        {
            Name = name;
            _all.Add(this);
            Id = _all.Count;
        }

        
        public static List<TamagotchiInstance> GetAll()
        {
            return _all;
        }

        public static TamagotchiInstance Find(int id)
        {
            return _all[id-1];
        }

        public static void ClearAll()
        {
            _all.Clear();
        }

       

        public static void MakeTimePass()
        {
           _all.ForEach(item => 
           {
               item.Food = item.Food - 1;
               item.Attention = item.Attention - 1;
               item.Rest = item.Rest - 1;
           });
        }

    }
}