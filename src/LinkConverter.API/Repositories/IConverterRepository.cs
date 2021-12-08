using LinkConverter.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Repositories
{
    public interface IConverterRepository
    {
        int Create(LinkConversion linkConversion);
        IEnumerable<LinkConversion> GetLinkConversion();
    }
}
