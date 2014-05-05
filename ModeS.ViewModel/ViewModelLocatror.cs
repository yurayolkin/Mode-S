using ModeS.Data;

namespace ModeS.ViewModel
{
    public class ViewModelLocatror
    {
        public ViewModelLocatror()
        {
            ServiceLoactor.Register<IData, DataBase>();
        }

        private MainView _mainView;
        public MainView Main
        {
            get
            {
                if (_mainView == null)
                {
                    _mainView = new MainView(ServiceLoactor.Resolve<IData>());
                }

                return _mainView;
            }
        }
    }
}