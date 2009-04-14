using System;
using System.Collections.Generic;
using System.Text;
using TogiApi;

namespace TimeLineControl
{
    public class ItemEvents: EventArgs
    {
        public Tweet t;

        public ItemEvents(Tweet t_)
        {
            t = t_;
        }
    }
}
