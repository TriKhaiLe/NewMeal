using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class FoodDays
    {
        public Food Food { get; set; }
        public DateTime Date { get; set; }
        public int Favourite { get; set; }
        public FoodDays()
        {
            Food = new Food();
            Date = DateTime.Now;    
            Favourite = 0;
        }
        public FoodDays(Food food , object time , int? like)
        {
            this.Food = food;
            if(time != null)
            {
                Date = (DateTime)time;  
            }
            Favourite =(int) like;
        }
    }
}
