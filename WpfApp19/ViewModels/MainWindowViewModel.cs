using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp19.Models;
using WpfApp19.ViewModels;

namespace WpfApp19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

    private double rad;
    public double Rad
    {
        get => rad;
        set
        {
            rad = value;
            OnPropertyChanged();
        }
    }

    private double res;
    public double Res
    {
        get => res;
        set
        {
            res = value;
            OnPropertyChanged();
        }
    }

    public ICommand CircleLengthCalcCommand { get; }
    private void OnCircleLengthCalcCommand(object p)
    {
        Res = Calculations.CircleLengthCalc(Rad);
    }

    private bool CanCircleLengthCalcCommandExecuted(object p)
    {
        if (Rad != 0)
            return true;
        else
            return false;
    }

    public MainWindowViewModel()
    {
        CircleLengthCalcCommand = new RelayCommand(OnCircleLengthCalcCommand, CanCircleLengthCalcCommandExecuted);
    }
}
}
