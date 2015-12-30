using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Pattern
{
    public interface ILogging
    {
        void SaveChangePreCommit();

        void SaveChangePostCommit();
    }
}
