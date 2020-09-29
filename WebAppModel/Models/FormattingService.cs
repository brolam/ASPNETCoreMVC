using System;

namespace WebAppModel.Models
{
    public class FormattingService
    {
        public string AsReadableDate(DateTime dateTime){
            return dateTime.ToString("D");
        }
    }
}
