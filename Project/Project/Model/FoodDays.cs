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
        public FoodDays()
        {
            Food = new Food();
            Date = DateTime.Now;    
        }
        public FoodDays(Food food , object time)
        {
            this.Food = food;
            if(time != null)
            {
                Date = (DateTime)time;  
            }
        }
    }
}
