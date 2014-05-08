using System;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using ModeS.Data;

namespace ModeS.ViewModel
{
    public class HistoryDetailsModelView : Notify
    {
        public ObservableCollection<Flight> History { get; set; }

        private Flight _selectAircraft;

        private DateTime _from;
        public DateTime From
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    OnPropertyChanged("From");
                }
            }
        }

        private DateTime _to;

        public DateTime To
        {
            get { return _to; }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    OnPropertyChanged("To");
                }
            }
        }

        private RelayCommand _historyDetails;
        public RelayCommand AircraftHistoryDetailsCommand
        {
            get { return (_historyDetails ?? (new RelayCommand(o =>
            {
                var data = ServiceLoactor.Resolve<IData>();
                var flight = data.GetFlights(From, To, string.Empty, string.Empty, _selectAircraft.Serial, string.Empty);
                if (History == null)
                {
                    History = new ObservableCollection<Flight>(flight);
                    return;
                }

                History.Clear();
                flight.ForEach(fl=> History.Add(fl));

            }, null))) ; }
        }

        public HistoryDetailsModelView(Flight flight)
        {
            _selectAircraft = flight;
            this.From = DateTime.Now.AddDays(-2);
            this.To = DateTime.Now;
            this.AircraftHistoryDetailsCommand.Execute(null);
        }
    }
}