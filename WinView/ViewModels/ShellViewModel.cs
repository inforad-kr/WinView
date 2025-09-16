using Caliburn.Micro;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WinView.Models;
using WinView.Services;

namespace WinView.ViewModels
{
    class ShellViewModel : Screen
    {
        readonly IStorageService m_StorageService;
        readonly DialogManager m_DialogManager;

        public ShellViewModel(DialogManager dialogManager)
        {
            m_StorageService = IoC.Get<IStorageService>(Settings.Default.StorageType);
            m_DialogManager = dialogManager;
        }

        public BindableCollection<Image> Images { get; } = new BindableCollection<Image>();

        Image m_SelectedImage;

        public Image SelectedImage
        {
            get => m_SelectedImage;
            set
            {
                Set(ref m_SelectedImage, value);
            }
        }

        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                try
                {
                    var imageUrls = await m_StorageService.GetImageUrls(args[1]);
                    if (imageUrls != null)
                    {
                        Images.AddRange(imageUrls.Select(imageUrl => new Image(imageUrl)));
                        SelectedImage = Images[0];
                    }
                }
                catch (Exception ex)
                {
                    m_DialogManager.HandleError(ex);
                }
            }
        }
    }
}
