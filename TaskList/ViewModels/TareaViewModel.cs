using ListaDeTareas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TaskList.Models;
using TaskList;

namespace NeoListaTareas
{
    public class TareaViewModel : NotificationObject
    {
        private ObservableCollection<Tarea> tareas;
        public ObservableCollection<Tarea> Tareas
        {
            get => tareas;
            set { tareas = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> tareasCompletas;
        public ObservableCollection<string> TareasCompletas
        {
            get => tareasCompletas;
            set { tareasCompletas = value; OnPropertyChanged(); }
        }

        public void AddTarea(int id, string desc, bool flag)
        {
            Tareas[id].Desc = desc;
            Tareas[id].Status = flag;
        }

        public TareaViewModel()
        {
            /*AddTarea(0, "Hacer la Cama", false);
            AddTarea(1, "Desayuno", false);
            AddTarea(2, "Ducha", false);*/

            PropertyChanged += Tareas_PropertyChanged;
            //SaveCommand = new Command(SaveCommandExecute);

        }

        /*Implementar la Funcion de Guardar en DB quizas con Messanging center porque necesito recibir el valor de la nueva tarea*/
        // Messanging Center en MainPage Subscribe a  ViewModel 
        // Aunque puede ser que Solo necesite SaveCommand pero todavia quedo sin el Parametro
        private async void SaveCommandExecute()
        {

            await Application.Current.SavePropertiesAsync();
        }

        public ICommand SaveCommand
        {
            get { return new Command<string>((x) => SaveDB(x)); }
        }

        /*public ICommand SaveCommand
        {
            set;
            get;
        }*/

        public async void SaveDB(string x)
        {
            if (!string.IsNullOrWhiteSpace(x))
            {
                await App.Database.SaveTareaAsync(new Tarea
                {
                    Desc = x,
                    Status = false
                });

                //collection.ItemsSource = await App.Database.GetTareaAsync();
            }
        }

        private void Tareas_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {


        }

        /*private async void UpdateTareas()
        {
            IEnumerable<Tarea> ListaDeTareas = (IEnumerable<Tarea>)await App.Database.GetTareaAsync();
            foreach (var item in ListaDeTareas)
            {
                if (item.Status)
                {

                }
            }
        }*/

    }
}
