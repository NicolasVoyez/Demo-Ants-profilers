using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestLeakingAppExternalLibrary;
using System.Windows;

namespace TestLeakingApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public MainViewModel()
        {
            Figures = new IPositionnable[0];
            OldFigures = new List<IPositionnable>();
        }

        private object _LockObject = new object();
        public ICommand WorkCommand
        {
            get
            {
                return new UltraBasicCommand(() =>
                {
                    try
                    {
                        OldFigures.AddRange(Figures);
                        Figures = LinesProvider.GetLines().ToArray<IPositionnable>();

                        var points = PointsProvider.GetPoints().ToList();
                        Parallel.ForEach(points, (data) =>
                        {
                            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                            {
                                try
                                {
                                    lock (_LockObject)
                                    {
                                        var size = Figures.Length + 1;
                                        IPositionnable[] newMocks = new IPositionnable[size];
                                        Figures.CopyTo(newMocks, 0);
                                        newMocks[size - 1] = data;
                                        Figures = newMocks;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }));

                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }

        private IPositionnable[] _Figures;
        public IPositionnable[] Figures
        {
            get { return _Figures; }
            private set
            {
                if (_Figures != value)
                {
                    _Figures = value;
                    NotifyPropertyChanged("Figures");
                }
            }
        }
        public List<IPositionnable> OldFigures { get; private set; }

    }
}
