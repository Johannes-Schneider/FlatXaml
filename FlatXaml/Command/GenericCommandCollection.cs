using System.Windows;

namespace FlatXaml.Command
{
    public static class GenericCommandCollection
    {
        public static GenericCommand CloseWindow { get; } = new GenericCommand(parameter => parameter is Window,
                                                                               parameter =>
                                                                               {
                                                                                   if (!(parameter is Window window))
                                                                                   {
                                                                                       return;
                                                                                   }

                                                                                   window.Dispatcher.Invoke(window.Close);
                                                                               });

        public static GenericCommand CancelDialog { get; } = new GenericCommand(parameter => parameter is Window,
                                                                                parameter =>
                                                                                {
                                                                                    if (!(parameter is Window window))
                                                                                    {
                                                                                        return;
                                                                                    }

                                                                                    window.Dispatcher.Invoke(() =>
                                                                                                             {
                                                                                                                 window.DialogResult = false;
                                                                                                                 window.Close();
                                                                                                             });
                                                                                });
    }
}