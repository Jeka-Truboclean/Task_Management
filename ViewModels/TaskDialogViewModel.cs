using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

public class TaskDialogViewModel : BaseViewModel
{
    public Task Task { get; set; }
    public ObservableCollection<Priority> Priorities { get; set; }
    public ICommand SaveCommand { get; set; }

    public TaskDialogViewModel(Task task)
    {
        Task = task;
        Priorities = new ObservableCollection<Priority> { Priority.Low, Priority.Medium, Priority.High };
        SaveCommand = new RelayCommand(Save);
    }

    private void Save(object parameter)
    {
        var window = parameter as Window;
        if (window != null)
        {
            window.DialogResult = true;
            window.Close();
        }
    }
}