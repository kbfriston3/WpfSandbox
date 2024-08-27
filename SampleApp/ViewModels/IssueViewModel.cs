using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
    public class IssueViewModel : Bases.ViewModelBase
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Subject { get; set; }
        public ObservableCollection<IssueViewModel> Children { get; set; }

        public bool IsExpanded { get; set; } = true;

        public ReactivePropertySlim<bool> IsExpandedRP { get; set; }

        public IssueViewModel(int id, string subject)
        {
            Id = id;
            Subject = subject;
            Children = new ObservableCollection<IssueViewModel>();

            this.ObserveProperty(a => a.IsExpanded).Subscribe(a =>
            {
                // Do something...
            });

            IsExpandedRP = new ReactivePropertySlim<bool>(true).AddTo(disposables);
            //IsExpanded.Subscribe(ie =>
            //{
            //});
        }

        public void ExpandAll()
        {
            IsExpanded = true;
            //IsExpandedRP.Value = true;
            foreach (var c in Children)
            {
                c.ExpandAll();
            }
        }

        public void CollapseAll()
        {
            foreach (var c in Children)
            {
                c.CollapseAll();
            }
            //IsExpandedRP.Value = false;
            IsExpanded = false;
        }
    }
}
