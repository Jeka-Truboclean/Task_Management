using System.Collections.ObjectModel;
using System.ComponentModel;

public class Project : INotifyPropertyChanged
{
    private string name;
    private string description;
    private ObservableCollection<Task> tasks;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Description
    {
        get { return description; }
        set
        {
            description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public ObservableCollection<Task> Tasks
    {
        get { return tasks; }
        set
        {
            tasks = value;
            OnPropertyChanged(nameof(Tasks));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Project()
    {
        Tasks = new ObservableCollection<Task>();
    }
}