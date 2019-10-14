using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
  /// <summary>
  /// Class created for Librarian Autentication
  /// </summary>
    class Autentication
    {

        //Method to autenticate Librarian

        #region Methods

        public bool Autentications(string userid,string password )
        {
            if ((userid == "skrishn24")&&(password =="Vinayka12!"))
            {
                return true;
            }

            return false;
        }

        #endregion


    }
}
