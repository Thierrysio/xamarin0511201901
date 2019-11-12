using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin0511201901.VueModeles
{
    class AuthentificationVueModele : INotifyPropertyChanged
    {
        #region Attributs

        private readonly ApiAuthentification _apiServices = new ApiAuthentification();
        //private readonly ApiClient _apiServices2 = new ApiClient();

        private string _identifiant;
        private string _motDePasse;


        #endregion

        #region Constructeurs
        public AuthentificationVueModele()
        {
            BoutonCommand = new Command(ActionPage);
        }
        #endregion

        #region Getters/Setters
        public ICommand BoutonCommand { get; }
        public string Identifiant
        {
            get
            {
                return _identifiant;
            }
            set
            {
                if (_identifiant != value)
                {
                    _identifiant = value;
                    OnPropertyChanged(nameof(Identifiant));
                }
            }
        }
        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }
            set
            {
                if (_motDePasse != value)
                {
                    _motDePasse = value;
                    OnPropertyChanged(nameof(MotDePasse));
                }
            }
        }
        #endregion

        #region Methodes

        public void ActionPage()
        {

            Task.Run(async () =>
            {
                await _apiServices.GetAuthAsync("riri@disney.com", "hello");

            });

            //Application.Current.MainPage = new NavigationPage(new ListeClientsPage());
        }
        #endregion
        #region notifications
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
