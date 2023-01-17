using CsvHelper;
using Financial.Core.ViewModels;
using System.Globalization;

namespace Financial.Core.Converter
{
    public class StockPriceConverter
    {
        public static string Execute(string value)
        {
            try
            {
                using var reader = new StringReader(value);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<StockPriceViewModel>().ToList();
                if (records is not null && records.Any())
                {
                    return records.First();
                }

                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }
    }
}
