using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagement;


public class MainViewModel : BaseViewModel
{
    private Project selectedProject;
    private Task selectedTask;

    public ObservableCollection<Project> Projects { get; set; }
    public Project SelectedProject
    {
        get { return selectedProject; }
        set
        {
            selectedProject = value;
            OnPropertyChanged(nameof(SelectedProject));
            OnPropertyChanged(nameof(SelectedProject.Tasks));
        }
    }

    public Task SelectedTask
    {
        get { return selectedTask; }
        set
        {
            selectedTask = value;
            OnPropertyChanged(nameof(SelectedTask));
        }
    }

    public ICommand AddProjectCommand { get; set; }
    public ICommand EditProjectCommand { get; set; }
    public ICommand DeleteProjectCommand { get; set; }
    public ICommand AddTaskCommand { get; set; }
    public ICommand EditTaskCommand { get; set; }
    public ICommand DeleteTaskCommand { get; set; }

    public MainViewModel()
    {
        Projects = new ObservableCollection<Project>();

        AddProjectCommand = new RelayCommand(AddProject);
        EditProjectCommand = new RelayCommand(EditProject, CanModifyProject);
        DeleteProjectCommand = new RelayCommand(DeleteProject, CanModifyProject);

        AddTaskCommand = new RelayCommand(AddTask, CanModifyProject);
        EditTaskCommand = new RelayCommand(EditTask, CanModifyTask);
        DeleteTaskCommand = new RelayCommand(DeleteTask, CanModifyTask);
    }

    private void AddProject(object parameter)
    {
        var newProject = new Project();
        var vm = new ProjectDialogViewModel(newProject);
        var dialog = new ProjectDialog { DataContext = vm };

        if (dialog.ShowDialog() == true)
        {
            Projects.Add(newProject);
            SelectedProject = newProject;
        }
    }

    private void EditProject(object parameter)
    {
        var vm = new ProjectDialogViewModel(SelectedProject);
        var dialog = new ProjectDialog { DataContext = vm };
        dialog.ShowDialog();
    }

    private void DeleteProject(object parameter)
    {
        Projects.Remove(SelectedProject);
    }

    private void AddTask(object parameter)
    {
        if (SelectedProject != null)
        {
            var newTask = new Task();
            var vm = new TaskDialogViewModel(newTask);
            var dialog = new TaskDialog { DataContext = vm };

            if (dialog.ShowDialog() == true)
            {
                SelectedProject.Tasks.Add(newTask);
                SelectedTask = newTask;
                OnPropertyChanged(nameof(SelectedProject.Tasks));
            }
        }
    }

    private void EditTask(object parameter)
    {
        var vm = new TaskDialogViewModel(SelectedTask);
        var dialog = new TaskDialog { DataContext = vm };
        if (dialog.ShowDialog() == true)
        {
            OnPropertyChanged(nameof(SelectedProject.Tasks));
        }
    }


    private void DeleteTask(object parameter)
    {
        if (SelectedProject != null)
        {
            SelectedProject.Tasks.Remove(SelectedTask);
            OnPropertyChanged(nameof(SelectedProject.Tasks));
        }
    }

    private bool CanModifyProject(object parameter)
    {
        return SelectedProject != null;
    }

    private bool CanModifyTask(object parameter)
    {
        return SelectedTask != null && SelectedProject != null;
    }
}