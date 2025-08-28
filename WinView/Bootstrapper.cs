using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WinView.Services;
using WinView.ViewModels;

namespace WinView
{
    class Bootstrapper : BootstrapperBase
    {
        readonly SimpleContainer m_Container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            m_Container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<DialogManager>();

            switch (Settings.Default.StorageType)
            {
                case 0:
                    m_Container.Singleton<IStorageService, SimpleStorageService>();
                    break;
            }

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => m_Container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key) => m_Container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type service) => m_Container.GetAllInstances(service);

        protected override void BuildUp(object instance) => m_Container.BuildUp(instance);
    }
}
