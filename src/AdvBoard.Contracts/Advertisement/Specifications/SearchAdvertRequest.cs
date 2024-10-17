using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Contracts.Advertisement.Specifications
{
    public class SearchAdvertRequest
    {
        /// <summary>
        /// Строка поиска.
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Минимальная цена.
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена.
        /// </summary>
        public decimal? MaxPrice { get; set; }
    }
}
