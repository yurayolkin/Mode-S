using ModeS.Data;
using ModeS.ViewModel.Core;

namespace ModeS.ViewModel
{
    public class ViewModelLocatror
    {
        public ViewModelLocatror()
        {
            ServiceLoactor.Register<IData, DataBase>();
            ServiceLoactor.Register<Messager>();
            ServiceLoactor.Register<HistoryDetailsModelView>();
        }

        private MainViewModel _mainViewModel;
        public MainViewModel Main
        {
            get
            {
               return _mainViewModel ?? (_mainViewModel = new MainViewModel(ServiceLoactor.Resolve<IData>()));
            }
        }

        private HistoryDetailsModelView _historyDetailsModelView;
        public HistoryDetailsModelView History
        {
            get { return _historyDetailsModelView ?? (new HistoryDetailsModelView(Main.SelectFlight)); }
        }
    }
}