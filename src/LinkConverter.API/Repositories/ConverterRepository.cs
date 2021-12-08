using LinkConverter.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace LinkConverter.API.Repositories
{
    public class ConverterRepository : IConverterRepository
    {
        private readonly DefaultDbContext _context;

        public ConverterRepository(DefaultDbContext context) 
        {
            _context = context;
        }
        public int Create(LinkConversion linkConversion)
        {
            int result = -1;
            if (linkConversion != null)
            {
                _context.LinkConversions.Add(linkConversion);
                result = _context.SaveChanges();
            }

            return result;

        }

        public IEnumerable<LinkConversion> GetLinkConversion()
        {
            return  _context.LinkConversions.ToList();
        }
    }
}
