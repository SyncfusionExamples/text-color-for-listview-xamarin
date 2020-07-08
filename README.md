# How to apply the ListView item text color in Xamarin.Forms (SfListView)
You can apply different text color to the element loaded inside the [ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html) by using the [TextColor](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.label.textcolor) property with converter in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview).

**XAML**

Define converter for **TextColor** of the [Label](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/label).

``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage">
    <ContentPage.BindingContext>
        <local:ContactsViewModel/>
    </ContentPage.BindingContext>
    
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:ColorConverter x:Key="ColorConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>
    
	 <ContentPage.Content>
        <StackLayout>
            <syncfusion:SfListView x:Name="listView" ItemSize="60" ItemsSource="{Binding ContactsInfo}">
                <syncfusion:SfListView.ItemTemplate >
                    <DataTemplate>
                        <Grid x:Name="grid">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                                <ColumnDefinition Width="100" />
                            </Grid.ColumnDefinitions>
                            <Image Source="{Binding ContactImage}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="50" WidthRequest="50"/>
                            <Grid Grid.Column="1" RowSpacing="1" Padding="10,0,0,0" VerticalOptions="Center">
                                <Label LineBreakMode="NoWrap" TextColor="{Binding .,Converter={StaticResource ColorConverter},ConverterParameter={x:Reference Name=listView}}" Text="{Binding ContactName}"/>
                                <Label Grid.Row="1" Grid.Column="0" TextColor="{Binding .,Converter={StaticResource ColorConverter},ConverterParameter={x:Reference Name=listView}}" LineBreakMode="NoWrap" Text="{Binding ContactNumber}"/>
                            </Grid>
                            <Label Grid.Column="2" TextColor="{Binding .,Converter={StaticResource ColorConverter},ConverterParameter={x:Reference Name=listView}}" LineBreakMode="NoWrap" Text="{Binding ContactType}" VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand"/>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

**C#**

Returns **TextColor** based on the **ContactType**.

``` c#
public class ColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return false;
        var itemdata = value as Contacts;
        if (itemdata.ContactType == "HOME")
            return Color.RoyalBlue;
        else if (itemdata.ContactType == "WORK")
            return Color.PaleGreen;
        else if (itemdata.ContactType == "MOBILE")
            return Color.HotPink;
        else if (itemdata.ContactType == "OTHER")
            return Color.DarkGoldenrod;
        else
            return Color.BlueViolet;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

**Output**

![TextColorListView](https://github.com/SyncfusionExamples/text-color-for-listview-xamarin/blob/master/ScreenShot/TextColorListView.png)
