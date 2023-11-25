using Microsoft.AspNetCore.Mvc.Rendering;
namespace WashingCarDB.Helpers
{
    public interface IDropDownListHelper
    {
                Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();

    }
}
