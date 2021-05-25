using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.Model;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        private byte viewMode = 0;
        public List<Bank> Banks { get; set; }
        private List<Label> labels = new List<Label>();

        public TablePage()
        {
            InitializeComponent();

            SetViewMode();

            Banks = new List<Bank>
            {
                new Bank { Name="Prior", LogoPath="null"},
                new Bank { Name="Alpha", LogoPath="null"},
                new Bank { Name="BankOfAnarchy", LogoPath="null"}
            };

            CreateList();
        }

        private void OnViewModelChanched()
        {
            if (viewMode == 0)
            {
                viewMode = 1;

                listView.IsVisible = false;
                listView.IsEnabled = false;

                gridStack.IsVisible = true;
                gridStack.IsEnabled = true;
            }
            else
            {
                viewMode = 0;

                listView.IsVisible = true;
                listView.IsEnabled = true;

                gridStack.IsVisible = false;
                gridStack.IsEnabled = false;
            }
        }

        private void SetViewMode()
        {
            gridStack.IsVisible = false;
            gridStack.IsEnabled = false;

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGesture.Tapped += (s, e) =>
            {
                OnViewModelChanched();
                //Navigation.PushModalAsync(new BankPage());
            };
            viewLabel.GestureRecognizers.Add(tapGesture);
        }

        protected override void OnAppearing()
        {
            ReShowLabels();

            base.OnAppearing();
        }

        private void CreateList()
        {
            listStack.ItemsSource = Banks;
            listStack.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star)},
                        new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star)},
                        new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star)},
                        new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star)},
                        new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star)},
                        new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star)}
                    }
                };

                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.FontSize = Device.GetNamedSize(NamedSize.Body, nameLabel);
                labels.Add(nameLabel);
                grid.Children.Add(nameLabel, 0, 0);

                Label currencyLabel = new Label();
                //currencyLabel.SetBinding(Label.TextProperty, "Name");
                currencyLabel.Text = "USD";
                currencyLabel.FontSize = Device.GetNamedSize(NamedSize.Body, currencyLabel);
                labels.Add(currencyLabel);
                grid.Children.Add(currencyLabel, 1, 0);

                Label buyLabel = new Label();
                //buyLabel.SetBinding(Label.TextProperty, "Name");
                buyLabel.Text = "2.70";
                buyLabel.FontSize = Device.GetNamedSize(NamedSize.Body, buyLabel);
                labels.Add(buyLabel);
                grid.Children.Add(buyLabel, 2, 0);

                Label sellLabel = new Label();
                //sellLabel.SetBinding(Label.TextProperty, "Name");
                sellLabel.Text = "2.69";
                sellLabel.FontSize = Device.GetNamedSize(NamedSize.Body, sellLabel);
                labels.Add(sellLabel);
                grid.Children.Add(sellLabel, 4, 0);

                Label bynLabel = new Label();
                bynLabel.Text = "BYN";
                bynLabel.FontSize = Device.GetNamedSize(NamedSize.Body, bynLabel);
                labels.Add(bynLabel);
                grid.Children.Add(bynLabel, 3, 0);
                grid.Children.Add(bynLabel, 5, 0);

                grid.Padding = new Thickness(5,5,5,5);
                return new ViewCell
                {
                    View = grid
                };
            });

            listStack.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                Navigation.PushModalAsync(new BankPage());
            };
        }

        private void CreateGrid()
        {

        }

        private void ReShowLabels()
        {
            foreach (var temp in labels)
            {
                temp.TextColor = App.UIBind.FontColor;
                temp.FontFamily = App.UIBind.CurrentFont;
            }
        }
    }
}