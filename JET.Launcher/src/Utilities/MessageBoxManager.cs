using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JET.Launcher.Utilities
{
    class MessageBoxManager
    {
        public enum Button
        {
            //
            // Summary:
            //     The message box displays an OK button.
            OK = 0,
            //
            // Summary:
            //     The message box displays OK and Cancel buttons.
            OKCancel = 1,
            //
            // Summary:
            //     The message box displays Yes, No, and Cancel buttons.
            YesNoCancel = 3,
            //
            // Summary:
            //     The message box displays Yes and No buttons.
            YesNo = 4
        }
        //
        // Summary:
        //     Specifies the icon that is displayed by a message box.
        public enum Image
        {
            //
            // Summary:
            //     No icon is displayed.
            None = 0,
            //
            // Summary:
            //     The message box contains a symbol consisting of a white X in a circle with a
            //     red background.
            Hand = 16,
            //
            // Summary:
            //     The message box contains a symbol consisting of white X in a circle with a red
            //     background.
            Stop = 16,
            //
            // Summary:
            //     The message box contains a symbol consisting of white X in a circle with a red
            //     background.
            Error = 16,
            //
            // Summary:
            //     The message box contains a symbol consisting of a question mark in a circle.
            Question = 32,
            //
            // Summary:
            //     The message box contains a symbol consisting of an exclamation point in a triangle
            //     with a yellow background.
            Exclamation = 48,
            //
            // Summary:
            //     The message box contains a symbol consisting of an exclamation point in a triangle
            //     with a yellow background.
            Warning = 48,
            //
            // Summary:
            //     The message box contains a symbol consisting of a lowercase letter i in a circle.
            Asterisk = 64,
            //
            // Summary:
            //     The message box contains a symbol consisting of a lowercase letter i in a circle.
            Information = 64
        }
        internal static void Show(
            string content,
            string title,
            Button messageBoxButton = Button.OK,
            Image messageBoxImage = Image.Information) {
                MessageBox.Show(
                    content,
                    title,
                    (MessageBoxButton)messageBoxButton,
                    (MessageBoxImage)messageBoxImage
                );
            }
    }
}
