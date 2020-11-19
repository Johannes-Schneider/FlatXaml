using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using FlatXaml.Extension;

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

        public static GenericCommand MinimizeWindow { get; } = new GenericCommand(parameter => parameter is Window,
                                                                                  parameter =>
                                                                                  {
                                                                                      if (!(parameter is Window window))
                                                                                      {
                                                                                          return;
                                                                                      }

                                                                                      window.Dispatcher.Invoke(() => window.WindowState = WindowState.Minimized);
                                                                                  });

        public static GenericCommand ToggleMaximizeWindow { get; } = new GenericCommand(parameter => parameter is Window,
                                                                                        parameter =>
                                                                                        {
                                                                                            if (!(parameter is Window window))
                                                                                            {
                                                                                                return;
                                                                                            }

                                                                                            window.Dispatcher.Invoke(() =>
                                                                                                                     {
                                                                                                                         return window.WindowState = window.WindowState switch
                                                                                                                                                     {
                                                                                                                                                         WindowState.Maximized => WindowState.Normal,
                                                                                                                                                         _ => WindowState.Maximized,
                                                                                                                                                     };
                                                                                                                     });
                                                                                        });

        public static GenericCommand ConfirmDialog { get; } = new GenericCommand(parameter => parameter is Window window && !window.HasValidationErrors(),
                                                                                 parameter =>
                                                                                 {
                                                                                     if (!(parameter is Window window) || window.HasValidationErrors())
                                                                                     {
                                                                                         return;
                                                                                     }

                                                                                     window.Dispatcher.Invoke(() =>
                                                                                                              {
                                                                                                                  window.DialogResult = true;
                                                                                                                  window.Close();
                                                                                                              });
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

        public static GenericCommand CopyToClipboard { get; } = new GenericCommand(parameter => parameter != null,
                                                                                   parameter =>
                                                                                   {
                                                                                       if (parameter == null)
                                                                                       {
                                                                                           return;
                                                                                       }

                                                                                       Clipboard.SetText(parameter.ToString() ?? string.Empty);
                                                                                   });

        public static GenericCommand OpenUrl { get; } = new GenericCommand(parameter => parameter is string,
                                                                           parameter =>
                                                                           {
                                                                               if (!(parameter is string stringParameter))
                                                                               {
                                                                                   return;
                                                                               }

                                                                               try
                                                                               {
                                                                                   Process.Start(stringParameter);
                                                                               }
                                                                               catch
                                                                               {
                                                                                   // hack because of this: https://github.com/dotnet/corefx/issues/10361
                                                                                   if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                                                                                   {
                                                                                       stringParameter = stringParameter.Replace("&", "^&");
                                                                                       Process.Start(new ProcessStartInfo("cmd", $"/c start {stringParameter}") {CreateNoWindow = true});
                                                                                   }
                                                                                   else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                                                                                   {
                                                                                       Process.Start("xdg-open", stringParameter);
                                                                                   }
                                                                                   else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                                                                                   {
                                                                                       Process.Start("open", stringParameter);
                                                                                   }
                                                                                   else
                                                                                   {
                                                                                       throw;
                                                                                   }
                                                                               }
                                                                           });
    }
}