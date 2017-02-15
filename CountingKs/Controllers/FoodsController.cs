using CountingKs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        public object Get()
        {
            var repo = new CountingKsRepository(new CountingKsContext());

            var results = repo.GetAllFoods()
                              .OrderBy(f => f.Description)
                              .Take(25)
                              .ToList();
            return results;
        }

    }
}
