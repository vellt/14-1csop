using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfKvizApp.Models;

namespace WpfKvizApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AnswerControl.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        Answer answer;
        public AnswerControl(Answer answer, string groupName)
        {
            InitializeComponent();
            this.answer = answer;
            SetAnswerData(answer);
            SetGroupName(groupName);
        }

        public bool IsTheAnswerCorrect()
        {
            return radioButtonControl.IsChecked == true && answer.Validity == AnswerValidity.Correct;
        }

        public bool IsChecked()
        {
            return radioButtonControl.IsChecked == true;
        }

        private void SetGroupName(string groupName)
        {
            radioButtonControl.GroupName = groupName;
        }

        private void SetAnswerData(Answer answer)
        {
            textBlockControl.Text = answer.Text;
            imageControl.Source = new BitmapImage(new Uri(answer.ImageSource));
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            radioButtonControl.IsChecked = true;
        }
    }
}
