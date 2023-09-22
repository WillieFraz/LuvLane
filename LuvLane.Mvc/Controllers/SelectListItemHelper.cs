using Microsoft.AspNetCore.Mvc.Rendering;

namespace LuvLane.Mvc.Controllers
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetGenderList()
        {

            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Male", Value = "0"},
                new SelectListItem{Text = "Female", Value = "1"}
            };
            return items;
        }
    }
}