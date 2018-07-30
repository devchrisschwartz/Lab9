 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Student
    {
        #region Fields
        private string name;
        private string hometown;
        private string favoriteFood;
        private string hobby;
        #endregion

        #region Properties
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Hometown
        {
            set { hometown = value; }
            get { return hometown; }
        }
        public string FavoriteFood
        {
            set { favoriteFood = value; }
            get { return favoriteFood; }
        }
        public string Hobby
        {
            set { hobby = value; }
            get { return hobby; }
        }
        #endregion

    }
}
