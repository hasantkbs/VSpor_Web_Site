using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace VSporBLL
{
    public class RoleFilterCalc
    {
        private readonly string[] _requestRoles;
        private readonly List<string> _userRoles;
        private readonly string _bolge;
        public RoleFilterCalc(List<string> userRoles, string requestRoles,string bolge)
        {
            _requestRoles = requestRoles.Split(',');
            _userRoles= userRoles;
            _bolge = bolge;
        }
        public string Run()
        {
          
            //foreach (var role in _requestRoles)
            //{
            //    if (_userRoles.Contains(role) && role== "PERSONELADMIN")
            //    {
            //        return string.Empty;
            //    }
            //}

            //foreach (var role in _requestRoles)
            //{
            //    if (_userRoles.Contains(role) && role == "PERSONEL")
            //    {
            //          return $"ikbolgeler.BusinessUnitId = '{_bolge}'";
            //    }
            //}
            
            throw new SecurityException("Yetkiniz yok!");

        }
    }
}
