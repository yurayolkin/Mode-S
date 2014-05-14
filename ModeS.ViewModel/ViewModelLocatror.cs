using ModeS.Data;
using ModeS.ViewModel.Core;

namespace ModeS.ViewModel
{
    public class ViewModelLocatror
    {
        public ViewModelLocatror(HistoryDetailsModelView historyDetailsModelView)
        {
            _historyDetailsModelView = historyDetailsModelView;
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

        private readonly HistoryDetailsModelView _historyDetailsModelView;
        public HistoryDetailsModelView History
        {
            get { return _historyDetailsModelView ?? (new HistoryDetailsModelView(Main.SelectFlight)); }
        }

        private MapViewModel _mapViewModel;

        public MapViewModel Map
        {
            get { return _mapViewModel ?? (_mapViewModel = new MapViewModel()); }
        }
    }
}