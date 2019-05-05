using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserComponents.DownLoadService
{
    public interface IDownLoadTask
    {
        void Start();
        void Stop();
        void Finish();
        void Fail();
        void Wait();
    }
}
