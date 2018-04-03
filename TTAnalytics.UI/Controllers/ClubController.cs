using System.Web.Http;
using TTAnalytics.Data;

namespace TTAnalytics.API.Controllers
{
    public class ClubController : ApiController
    {
        private TTAnalyticsContext _context;

        public ClubController(TTAnalyticsContext context)
        {
            _context = context;
        }

        
    }
}