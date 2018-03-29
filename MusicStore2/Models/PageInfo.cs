using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore2.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } //номерочек страницы
        public int PageSize { get; set; } //сколько инструментов на странице
        public int TotalItems { get; set; } //всего инструментов
        public int TotalPages //всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }

    public class IndexViewModel
    {
        public IEnumerable<Instrument> Instruments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}