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

        private Tuple<string, string> _personToDelete;

        private event EventHandler<EventArgs> PersonDeleted;

        public AdminPresenter(IActionAdapter adapter)
        {
            _adapter = adapter;

            _adminView = new AdminView();

            _adminView.AdminRequested += OnAdminRequested;
            _adminView.AdminDeleted += OnAdminDeleted;
            this.PersonDeleted += OnPersonDeleted;

            _adminModel.ModelUpdated += OnModelUpdated;
            
        }
       
        //---------------------Delete Button-------------------------

        private void OnAdminDeleted(object? sender, EventArgs e)
        {
            // selected Person von View 
            _personToDelete = _adminView._selectedUserDelete;
            PersonDeleted?.Invoke(this, EventArgs.Empty);
        }

        private async void OnPersonDeleted(object? sender, EventArgs e)
        {
            RemoteActionRequest AdminDelete = new RemoteActionRequest(ActionType.AdminDelete, _personToDelete.Item1, _personToDelete.Item2);
            await ProcessRequest(AdminDelete);
        }

        //-------------------Connect Button-----------------------
        private async void OnAdminRequested(object? sender, EventArgs e)
        {
            RemoteActionRequest AdminRequest = new RemoteActionRequest(ActionType.Admin, "admin", "admin");
            await ProcessRequest(AdminRequest);
        }

        //------------------------------------------------------------
        private async Task ProcessRequest(RemoteActionRequest adminRequest)
        {
            RemoteActionResponse response = await _adapter.PerformActionAsync(adminRequest);

            //response auspacken!

            switch (response.Type)
            {
                case ResponseType.Error:
                    _adminView.ShowErrorMessage(response.Message);
                    break;
                case ResponseType.Success:
                    //Model aufrufen -> UserList Speichern
                    _adminModel.SavaData(response.Message);
                    
                    break;

                case ResponseType.SuccessDelete:
                    _adminView.UpdateView(response.Message);
                    break;

                default:

                    break;
            }

        }

        private void OnModelUpdated(object? sender, EventArgs e)
        {
            //UserListe wurde geUpdated -> Event -> View

            _adminView.ConnectionSuccess(_adminModel.UserList);
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
