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

        private AdminView _adminView;
        private AdminModel _adminModel;

        public AdminPresenter(IActionAdapter adapter)
        {
            _adapter = adapter;

            _adminView = new AdminView();

            _adminView.AdminRequested += OnAdminRequested;
            
            
        }

        private async void OnAdminRequested(object? sender, EventArgs e)
        {
            RemoteActionRequest AdminRequest = new RemoteActionRequest(ActionType.Admin, "admin", "admin");
            await ProcessRequest(AdminRequest);
        }

        private async Task ProcessRequest(RemoteActionRequest adminRequest)
        {
            RemoteActionResponse response = await _adapter.PerformActionAsync(adminRequest);

            switch (response.Type)
            {
                case ResponseType.Error:
                    _adminView.ShowErrorMessage(response.Message);
                    break;
                case ResponseType.Success:
                    _adminView.ConnectionSuccess(response.Message);
                    break;
            }

        }

        public void OpenUI(bool isModal)
        {
            if (isModal)
            {
                _adminView.ShowDialog();
            }
            else
            {
                _adminView.Show();
            }


        }




    }
}
