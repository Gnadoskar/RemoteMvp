using RemoteMvpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMVPAdmin
{    
    public class AdminPresenter
    {
        private readonly IActionAdapter _adapter;

        public AdminPresenter(IActionAdapter adapter)
        {
            _adapter = adapter;


            
        }

    }
}
