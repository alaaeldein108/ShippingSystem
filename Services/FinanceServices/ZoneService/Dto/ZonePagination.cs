﻿using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FinanceServices.ZoneService.Dto
{
    public class ZonePagination
    {
        public string? Name { get; set; }
        public int? Destination { get; set; }
        public ZoneTypeEnum? ZoneType { get; set; }
        public string? StaAffailiatedBranchCodetus { get; set; }

        public int PageIndex { get; set; } = 1;
        private const int MAXPAGESIZE = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value; }
        }
    }
}
