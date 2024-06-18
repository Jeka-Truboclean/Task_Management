using System.ComponentModel;

public class Task : INotifyPropertyChanged
{
    private string name;
    private string description;
    private Priority priority;
    private bool isCompleted;

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

    public Priority Priority
    {
        get { return priority; }
        set
        {
            priority = value;
            OnPropertyChanged(nameof(Priority));
        }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set
        {
            isCompleted = value;
            OnPropertyChanged(nameof(IsCompleted));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public enum Priority
{
    Low,
    Medium,
    High
}
