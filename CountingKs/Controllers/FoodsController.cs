using CountingKs.Data;
using System.Linq;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        ICountingKsRepository _repo;

        public FoodsController(ICountingKsRepository repo)
        {
            _repo = repo;
        }
        public object Get()
        {
            //var repo = new CountingKsRepository(new CountingKsContext());

            var results = _repo.GetAllFoods()
                              .OrderBy(f => f.Description)
                              .Take(5)
                              .ToList();
            return results;
        }

    }
}
