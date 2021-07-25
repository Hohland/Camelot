using System.Windows.Input;
using Camelot.Services.Abstractions;
using Camelot.Services.Abstractions.Models;
using Camelot.ViewModels.Interfaces.MainWindow.Directories;
using Camelot.ViewModels.Services.Interfaces;
using ReactiveUI;

namespace Camelot.ViewModels.Implementations.MainWindow.FavouriteDirectories
{
    public class FavouriteDirectoryViewModel : ViewModelBase, IFavouriteDirectoryViewModel
    {
        private readonly IFilesOperationsMediator _filesOperationsMediator;
        private readonly IFavouriteDirectoriesService _favouriteDirectoriesService;
        
        public string FullPath { get; }
        
        public string DirectoryName { get; }

        public ICommand OpenCommand { get; }

        public ICommand RemoveCommand { get; }

        public FavouriteDirectoryViewModel(
            IFilesOperationsMediator filesOperationsMediator,
            IFavouriteDirectoriesService favouriteDirectoriesService,
            DirectoryModel directoryModel)
        {
            _filesOperationsMediator = filesOperationsMediator;
            _favouriteDirectoriesService = favouriteDirectoriesService;

            FullPath = directoryModel.FullPath;
            DirectoryName = directoryModel.Name;

            OpenCommand = ReactiveCommand.Create(Open);
            RemoveCommand = ReactiveCommand.Create(Remove);
        }

        private void Open() =>
            _filesOperationsMediator.ActiveFilesPanelViewModel.CurrentDirectory = FullPath;

        private void Remove() => _favouriteDirectoriesService.RemoveDirectory(FullPath);
    }
}