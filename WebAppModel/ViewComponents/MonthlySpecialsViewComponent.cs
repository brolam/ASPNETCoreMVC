using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAppModel.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return "TODO: Show monthly sepecial";
        }
    }
}
