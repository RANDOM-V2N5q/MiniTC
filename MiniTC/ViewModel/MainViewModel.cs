using MiniTC.Model;
using MiniTC.ViewModel.BaseClass;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniTC.ViewModel {
    class MainViewModel : ViewModelBase {
        private MainModel mainModel = new MainModel();

        public String PathContent { get { return Properties.Resources.PathContent; } }
        public String DriveContent { get { return Properties.Resources.DriveContent; } }
        public String CopyButtonContent { get { return Properties.Resources.CopyButtonContent; } }

        public String LeftPanelPath {
            get { return mainModel.LeftPanel.Path; }
        }
        public String[] LeftPanelDrives {
            get { return mainModel.LeftPanel.Drives; }
        }
        public ObservableCollection<String> LeftPanelItems {
            get { return new ObservableCollection<String>(mainModel.LeftPanel.Items); }
        }
        public Int32 LeftPanelSelectedDriveIndex {
            set {
                mainModel.LeftPanel.SelectedDriveIndex = value;
                OnPropertyChanged(nameof(LeftPanelPath));
                OnPropertyChanged(nameof(LeftPanelItems));
            }
        }

        public Int32 leftPanelSelectedItemIndex = -1;
        public Int32 LeftPanelSelectedItemIndex {
            get { return leftPanelSelectedItemIndex; }
            set { leftPanelSelectedItemIndex = value; }
        }

        public String RightPanelPath {
            get { return mainModel.RightPanel.Path; }
        }
        public String[] RightPanelDrives {
            get { return mainModel.RightPanel.Drives; }
        }
        public ObservableCollection<String> RightPanelItems {
            get { return new ObservableCollection<String>(mainModel.RightPanel.Items); }
        }
        public Int32 RightPanelSelectedDriveIndex {
            set {
                mainModel.RightPanel.SelectedDriveIndex = value;
                OnPropertyChanged(nameof(RightPanelPath));
                OnPropertyChanged(nameof(RightPanelItems));
            }
        }

        public Int32 rightPanelSelectedItemIndex = -1;
        public Int32 RightPanelSelectedItemIndex {
            set { rightPanelSelectedItemIndex = value; }
            get { return leftPanelSelectedItemIndex; }
        }


        private ICommand copy = null;
        public ICommand Copy {
            get {
                if(copy == null) {
                    copy = new RelayCommand(CopyExecute, CopyCanExecute);
                }

                return copy;
            }
        }
        private void CopyExecute( object arg ) {
            mainModel.Copy();
            OnPropertyChanged(nameof(RightPanelItems));
        }
        private Boolean CopyCanExecute( object arg ) {
            if(mainModel.LeftPanel.SelectedItemIndex > -1) {
                return true;
            }
            else {
                return false;
            }
        }


        private ICommand updateList = null;
        public ICommand UpdateList {
            get {
                if(updateList == null) {
                    updateList = new RelayCommand(UpdateListExecute, UpdateListCanExecute);
                }

                return updateList;
            }
        }
        private void UpdateListExecute( object arg ) {
            OnPropertyChanged(nameof(LeftPanelDrives));
            OnPropertyChanged(nameof(RightPanelDrives));
        }
        private Boolean UpdateListCanExecute( object arg ) {
            return true;
        }


        private ICommand leftPanelSelectItem = null;
        public ICommand LeftPanelSelectItem {
            get {
                if(leftPanelSelectItem == null) {
                    leftPanelSelectItem = new RelayCommand(LeftPanelSelectItemExecute, LeftPanelSelectItemCanExecute);
                }

                return leftPanelSelectItem;
            }
        }
        private void LeftPanelSelectItemExecute( object arg ) {
            mainModel.LeftPanel.SelectedItemIndex = leftPanelSelectedItemIndex;
            OnPropertyChanged(nameof(LeftPanelPath));
            OnPropertyChanged(nameof(LeftPanelItems));
        }
        private Boolean LeftPanelSelectItemCanExecute( object arg ) {
            return true;
        }


        private ICommand rightPanelSelectItem = null;
        public ICommand RightPanelSelectItem {
            get {
                if(rightPanelSelectItem == null) {
                    rightPanelSelectItem = new RelayCommand(RightPanelSelectItemExecute, RightPanelSelectItemCanExecute);
                }

                return rightPanelSelectItem;
            }
        }
        private void RightPanelSelectItemExecute( object arg ) {
            mainModel.RightPanel.SelectedItemIndex = rightPanelSelectedItemIndex;
            OnPropertyChanged(nameof(RightPanelPath));
            OnPropertyChanged(nameof(RightPanelItems));
        }
        private Boolean RightPanelSelectItemCanExecute( object arg ) {
            return true;
        }
    }
}
