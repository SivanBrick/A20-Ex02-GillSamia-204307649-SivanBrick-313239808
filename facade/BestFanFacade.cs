using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EX02
{
    class BestFanFacade
    {
        private TopPostsLiker m_topPostsLiker = new TopPostsLiker();
        private TopPhotosLiker m_topPhotosLiker = new TopPhotosLiker();
        private TopCommenter m_topCommenter = new TopCommenter();
    }
}
