using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels.Bases
{
    [Serializable]
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
#pragma warning disable 0067
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

        [NonSerialized]
        protected CompositeDisposable disposables = new CompositeDisposable();

        public void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public virtual void Dispose()
        {
            disposables.Dispose();
        }
    }
}
