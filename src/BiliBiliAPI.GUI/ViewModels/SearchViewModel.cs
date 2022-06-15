using BilibiliAPI.Search;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.GUI.ViewModels
{
    public class SearchViewModel:ObservableRecipient
    {
        public SearchViewModel()
        {
            IsActive = true;
            SearchClick = new RelayCommand(async () =>
            {
                PublicSearch search = new PublicSearch();
                var a = await search.SearchAnimation("时光代理人", "1");
            });
        }
        private string SearchText;

        public string _SearchText
        {
            get { return SearchText; }
            set => SetProperty(ref SearchText, value);
        }


        public RelayCommand SearchClick { get; set; }
    }
}
