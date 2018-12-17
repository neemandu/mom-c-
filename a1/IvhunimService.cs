using a1.TestsTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a1
{
    public class IvhunimService : IIvhunimService
    {
        private IToni _toniTest;
        public IvhunimService(IToni toniTest)
        {
            _toniTest = toniTest;
        }

        public IvhunFinalResult ProcessIvhun(IIvhunimService ivhun)
        {
            throw new NotImplementedException();
        }
    }
}