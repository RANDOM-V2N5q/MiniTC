using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MiniTC {
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl {
        public PanelTC() {
            InitializeComponent();
        }

        #region Path
        public static DependencyProperty LabelPathContentProperty = DependencyProperty.Register(
            "LabelPathContent",
            typeof(string),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string LabelPathContent {
            get { return (string)GetValue(LabelPathContentProperty); }
            set { SetValue(LabelPathContentProperty, value); }
        }

        public static DependencyProperty TextBoxTextProperty = DependencyProperty.Register(
            "TextBoxText",
            typeof(string),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string TextBoxText {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }
        #endregion Path

        #region ComboBox
        public static DependencyProperty LabelDriveContentProperty = DependencyProperty.Register(
            "LabelDriveContent",
            typeof(string),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string LabelDriveContent {
            get { return (string)GetValue(LabelDriveContentProperty); }
            set { SetValue(LabelDriveContentProperty, value); }
        }

        public static DependencyProperty ComboBoxSelectedIndexProperty = DependencyProperty.Register(
            "ComboBoxSelectedIndex",
            typeof(Int32),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public Int32 ComboBoxSelectedIndex {
            get { return (Int32)GetValue(ComboBoxSelectedIndexProperty); }
            set { SetValue(ComboBoxSelectedIndexProperty, value); }
        }

        public static DependencyProperty ComboBoxItemsSourceProperty = DependencyProperty.Register(
            "ComboBoxItemsSource",
            typeof(string[]),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string[] ComboBoxItemsSource {
            get { return (string[])GetValue(ComboBoxItemsSourceProperty); }
            set { SetValue(ComboBoxItemsSourceProperty, value); }
        }

        public static DependencyProperty ComboBoxSelectedItemProperty = DependencyProperty.Register(
            "ComboBoxSelectedItem",
            typeof(string),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string ComboBoxSelectedItem {
            get { return (string)GetValue(ComboBoxSelectedItemProperty); }
            set { SetValue(ComboBoxSelectedItemProperty, value); }
        }

        public static readonly RoutedEvent DropDownOpenedEvent = EventManager.RegisterRoutedEvent(
            "DropDownOpened",
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(PanelTC)
        );
        public event RoutedEventHandler DropDownOpened {
            add { AddHandler(DropDownOpenedEvent, value); }
            remove { RemoveHandler(DropDownOpenedEvent, value); }
        }
        void RaiseDropDownOpened() {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PanelTC.DropDownOpenedEvent);
            RaiseEvent(newEventArgs);
        }
        private void ComboBox_DropDownOpened( object sender, EventArgs e ) {
            RaiseDropDownOpened();
        }
        #endregion ComboBox

        #region ListBox
        public static readonly RoutedEvent LeftButtonDownEvent = EventManager.RegisterRoutedEvent(
            "LeftButtonDown",
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(PanelTC)
        );
        public event RoutedEventHandler LeftButtonDown {
            add { AddHandler(LeftButtonDownEvent, value); }
            remove { RemoveHandler(LeftButtonDownEvent, value); }
        }
        void RaiseLeftButtonDown() {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PanelTC.LeftButtonDownEvent);
            RaiseEvent(newEventArgs);
        }
        private void ListBox_MouseLeftButtonDown( object sender, EventArgs e ) {
            RaiseLeftButtonDown();
        }

        public static readonly RoutedEvent LeftButtonUpEvent = EventManager.RegisterRoutedEvent(
            "LeftButtonUp",
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(PanelTC)
        );
        public event RoutedEventHandler LeftButtonUp {
            add { AddHandler(LeftButtonUpEvent, value); }
            remove { RemoveHandler(LeftButtonUpEvent, value); }
        }
        void RaiseLeftButtonUp() {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PanelTC.LeftButtonUpEvent);
            RaiseEvent(newEventArgs);
        }
        private void ListBox_MouseLeftButtonUp( object sender, EventArgs e ) {
            RaiseLeftButtonUp();
        }

        public static DependencyProperty ListBoxItemsSourceProperty = DependencyProperty.Register(
            "ListBoxItemsSource",
            typeof(ObservableCollection<String>),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public ObservableCollection<String> ListBoxItemsSource {
            get { return (ObservableCollection<String>)GetValue(ListBoxItemsSourceProperty); }
            set { SetValue(ListBoxItemsSourceProperty, value); }
        }

        public static DependencyProperty ListBoxSelectedIndexProperty = DependencyProperty.Register(
            "ListBoxSelectedIndex",
            typeof(Int32),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public Int32 ListBoxSelectedIndex {
            get { return (Int32)GetValue(ListBoxSelectedIndexProperty); }
            set { SetValue(ListBoxSelectedIndexProperty, value); }
        }

        public static DependencyProperty ListBoxSelectedItemProperty = DependencyProperty.Register(
            "ListBoxSelectedItem",
            typeof(string),
            typeof(PanelTC),
            new FrameworkPropertyMetadata(null)
        );
        public string ListBoxSelectedItem {
            get { return (string)GetValue(ListBoxSelectedItemProperty); }
            set { SetValue(ListBoxSelectedItemProperty, value); }
        }
        #endregion ListBox
    }
}