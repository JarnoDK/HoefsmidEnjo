
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace HoefsmidEnjo.Shared.Invoice{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy HH:mm";
        }

        public DateFormatConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }
}