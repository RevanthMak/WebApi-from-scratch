using CountingKs.Data;
using System.Linq;
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
                              .Take(5)
                              .ToList();
            return results;
        }

    }
}
