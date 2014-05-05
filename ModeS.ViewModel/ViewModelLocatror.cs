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
               return _mainView ?? (_mainView = new MainView(ServiceLoactor.Resolve<IData>()));
            }
        }
    }
}