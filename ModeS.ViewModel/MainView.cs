using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ModeS.Data;

namespace ModeS.ViewModel
{
    public class MainView : Notify
    {
        public ObservableCollection<Flight> Flights { get; set; }

        public ObservableCollection<string> Countries { get; set; }

        public ObservableCollection<string> AirCrafts { get; set; }

        public ObservableCollection<string> Operators { get; set; }

        public ObservableCollection<string> Serials { get; set; }

        public ContextMenu ContextMenu { get; set; }

        private DateTime _dateTimeStart;

        public DateTime DateTimeStart
        {
            get { return _dateTimeStart; }
            set
            {
                _dateTimeStart = value;
                OnPropertyChanged("DateTimeStart");
            }
        }

        private DateTime _dateTimeEnd;

        public DateTime DateTimeEnd
        {
            get { return _dateTimeEnd; }
            set
            {
                _dateTimeEnd = value;
                OnPropertyChanged("DateTimeEnd");
            }
        }

        private string _countrySelect;

        public string CountrySelect
        {
            get { return _countrySelect; }
            set
            {
                _countrySelect = value;
                OnPropertyChanged("CountrySelect");
            }
        }

        private string _airCraftSelect;

        public string AirCraftSelect
        {
            get { return _airCraftSelect; }
            set
            {
                _airCraftSelect = value;
                OnPropertyChanged("AirCraftSelect");
                Serials.Clear();
                var result = _data.GetSerials(value);
                foreach (string serial in result)
                {
                    Serials.Add(serial);
                }
            }
        }

        private string _serialSelect;

        public string SerialSelect
        {
            get { return _serialSelect; }
            set
            {
                _serialSelect = value;
                OnPropertyChanged("SerialSelect");
            }
        }

        private RelayCommand _queryCommand;

        public RelayCommand QueryCommand
        {
            get
            {
                if (_queryCommand == null)
                {
                    _queryCommand = new RelayCommand((o) =>
                    {
                        var flights = _data.GetFlights(DateTimeStart, DateTimeEnd, CountrySelect, AirCraftSelect,
                            SerialSelect, OpatorSelect);
                        if (flights.Count != 0)
                        {
                            Flights.Clear();
                            foreach (var flight in flights)
                            {
                                Flights.Add(flight);
                            }
                        }
                    }, null);
                }

                return _queryCommand;
            }
        }

        private RelayCommand _aircraftHistory;

        public RelayCommand AirCraftHistoryCommand
        {
            get { return _aircraftHistory ?? (new RelayCommand((o) => { }, null)); }
        }

        private RelayCommand _aircraftDetails;

        public RelayCommand AirCraftDetailsCommand
        {
            get { return _aircraftDetails ?? (new RelayCommand((o) => { }, null)); }
        }

        private RelayCommand _map;

        public RelayCommand MapCommand
        {
            get { return _map ?? (new RelayCommand((o) => { }, null)); }
        }

        private string _operatorSelect;

        public string OpatorSelect
        {
            get { return _operatorSelect; }
            set
            {
                if (_operatorSelect != value)
                {
                    _operatorSelect = value;
                    OnPropertyChanged("OperatorSelect");
                }
            }
        }

        private readonly IData _data;

        public MainView(IData data)
        {
            _data = data;
            _dateTimeStart = _dateTimeEnd = DateTime.Now;
            Flights =
                new ObservableCollection<Flight>(data.GetFlights(_dateTimeStart, _dateTimeEnd, string.Empty,
                    string.Empty, string.Empty, string.Empty));
            Countries = new ObservableCollection<string>(data.GetCountriList());
            AirCrafts = new ObservableCollection<string>(data.GetAirCraftList());
            Operators = new ObservableCollection<string>(data.GetOperators());
            Serials = new ObservableCollection<string>();
            DateTimeEnd = DateTimeStart = DateTime.Now;
        }

        public MainView() : this(ServiceLoactor.Resolve<IData>())
        {
        }
    }
}
