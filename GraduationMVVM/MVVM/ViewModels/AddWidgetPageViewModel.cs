using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class AddWidgetPageViewModel : ObservableObject
    {
        public string WidgetType { get; set; }
        public string WidgetName { get; set; }
        public int StreamId { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }

        public bool isSaved = false;

        public AddWidgetPageViewModel()
        {
            WidgetName = string.Empty;
        }


        [RelayCommand]
        public async void AddWidget()
        {
            if (WidgetType != null && WidgetType != "" && WidgetType != "Type of Widget")
            {
                switch (WidgetType)
                {
                    case "Button":

                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            App.ButtonRepository.AddorUpdateItem(new ButtonModel
                            {
                                ButName = WidgetName,
                                DeviceId = App.SelectedDevice.Id,
                                StreamId = StreamId,
                                Value0 = Value0,
                                Value1 = Value1,
                            });

                            isSaved = true;
                            App.SelectedDevice.Buttons = new System.Collections.ObjectModel.ObservableCollection<ButtonModel>(App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Please Enter a Widget Name", "OK");
                            isSaved = false;
                            return;
                        }
                        InsertCheck(isSaved);
                        break;


                    case "Switch":

                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            App.SwitchRepository.AddorUpdateItem(new SwitchModel
                            {
                                SwName = WidgetName,
                                DeviceId = App.SelectedDevice.Id,
                                StreamId = StreamId,
                                Value0 = Value0,
                                Value1 = Value1,
                            });

                            isSaved = true;
                            App.SelectedDevice.Switchs= new System.Collections.ObjectModel.ObservableCollection<SwitchModel>(App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Please Enter a Widget Name", "OK");
                            isSaved = false;
                            return;
                        }
                        InsertCheck(isSaved);
                        break;


                    case "Gauge":
                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            App.GaugeRepository.AddorUpdateItem(new GaugeModel
                            {
                                GaugeName = WidgetName,
                                DeviceId = App.SelectedDevice.Id,
                                StreamId = StreamId,
                                Value0 = Value0,
                                Value1 = Value1,
                            });

                            isSaved = true;

                            App.SelectedDevice.Gauges = new System.Collections.ObjectModel.ObservableCollection<GaugeModel>(App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Please Enter a Widget Name", "OK");
                            isSaved = false;
                            return;
                        }
                        InsertCheck(isSaved);
                        break;


                    case "Slider":

                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            App.SliderRepository.AddorUpdateItem(new SliderModel
                            {
                                SliderName = WidgetName,
                                DeviceId = App.SelectedDevice.Id,
                                StreamId = StreamId,
                                Value0 = Value0,
                                Value1 = Value1

                            });

                            isSaved = true;
                            App.SelectedDevice.Sliders = new System.Collections.ObjectModel.ObservableCollection<SliderModel>(App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Please Enter a Widget Name", "OK");
                            isSaved = false;
                            return;
                        }
                        InsertCheck(isSaved);
                        break;
                };
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please Select a Widget Type", "OK");
            }

        }

        public async void InsertCheck(bool isSaved)
        {
            if (isSaved)
            {
                bool state = await Shell.Current.DisplayAlert("Success", "Widget Added", "OK", "Add More");
                AddDeviceViewModel.isSaved = false;
                if (state)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    WidgetName = "";
                    StreamId = 0;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Fail", "Widget not Added", "OK");
            }
        }
    }
}
