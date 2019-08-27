using System;
using Cesar.Domain.CesarContext.Enums;
using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.Entities
{
    public class JobTitle : Notification
    {
        private readonly int _MaxTamNameJobTitle = 20;
        private readonly int _MinTamNameJobTitle = 5; 
        public JobTitle(string nameTitle, EStatusJobTitle statusJobTitle)
        {
            NameTitle = nameTitle;
            StatusJobTitle = statusJobTitle;
            CreateDate = DateTime.UtcNow.AddHours(-3);
             if (!Comparators.IsLengthGranThan("NameTitle", _MaxTamNameJobTitle))
                AddNotification("FirstName", $"O nome do trabalho possui o tamanho {NameTitle.Length}. Ele precisa ter o tamanho menor do que {_MaxTamNameJobTitle}");
            if (!Comparators.IsLengthLessThan("FirstName", _MinTamNameJobTitle))
                AddNotification("FirstName", $"O nome do trabalho possui o tamanho {NameTitle.Length}. Ele precisa ter o tamanho maior do que {_MinTamNameJobTitle}");
        }
        public string NameTitle { get; private set; }
        public EStatusJobTitle StatusJobTitle { get; private set; }
        public DateTime CreateDate { get; private set; }
        public override string ToString(){
            return NameTitle;
        }
    }
}