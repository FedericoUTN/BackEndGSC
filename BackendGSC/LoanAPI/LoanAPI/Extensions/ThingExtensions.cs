using LoadApi.Entities;
using LoanAPI.Models;

namespace LoanAPI.Extensions
{
    public static class ThingExtensions
    {
        
          public static ThingViewModel ToViewModel(this Thing thing)
        {
            return new ThingViewModel { 
                Id = thing.Id,
                Description = thing.Description,
                CategoryId = thing.CategoryId
            };
        }

        public static List<ThingViewModel> ToViewModels(this List<Thing> thing)
        {
            var list = new List<ThingViewModel>();
            thing.ForEach(t => list.Add(t.ToViewModel()));

            return list;
        }

        public static Thing ToEntity(this ThingViewModel thingVM)
        {
            return new Thing 
            {
                Id = thingVM.Id,
                Description = thingVM.Description,
                CategoryId =thingVM.CategoryId

            };
        }
         
    }
}
