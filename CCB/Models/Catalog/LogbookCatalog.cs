﻿using CCB.Data.Domain;
using CCB.Models.Base;

namespace CCB.Models.Catalog
{
    public class LogbookCatalog : CatalogAppBase<Logbook>
    {
        public LogbookCatalog()
        {
            int count = All.Count;
        }
    }
}