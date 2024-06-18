using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

public class ProjectDialogViewModel : BaseViewModel
{
    public Project Project { get; set; }
    public ICommand SaveCommand { get; set; }

    public ProjectDialogViewModel(Project project)
    {
        Project = project;
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
