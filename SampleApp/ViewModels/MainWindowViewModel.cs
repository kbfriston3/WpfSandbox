using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SampleApp.Attribute;
using SampleApp.Converters;
using SampleApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
    public class MainWindowViewModel : Bases.ViewModelBase
    {
        public ReactiveCommand TestCommand { get; set; }
        public List<string> Items { get; set; }
        public string Item { get; set; } = "default";

        public MainWindowViewModel()
        {
            Items = new List<string>() { "aaa", "bbb", "ccc", "default" };

            TestCommand = new ReactiveCommand().WithSubscribe(() =>
            {
                Items = new List<string> { "1", "2", "3" };
            });
        }
    }
}
