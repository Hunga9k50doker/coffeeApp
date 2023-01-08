using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

//[assembly:Dependency(typeof(CoffeeService))]
namespace MyCoffeeApp.Services
{
    public class CoffeeService 
    {
        private readonly SQLiteConnection db;
        public CoffeeService()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, "MyData1.db3"));

            //db.CreateTable<Coffee>();
            //db.CreateTable<User>();
            //db.CreateTable<Cart>();
            //db.CreateTable<Favorite>();

        }

        public bool AddCoffee(Coffee cf)
        {
            try
            {
                db.Insert(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }

        public bool Register(User us)
        {
            try
            {
                db.Insert(us);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }
        public bool Login(User us)
        {
            try
            {
                var res= db.Table<User>().Where(o => o.username.Equals(us.username)&& o.password.Equals(us.password)).FirstOrDefault();
                if (res!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }
        public bool AddCoffeeToFav(Favorite cf)
        {
            try
            {
                db.Insert(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }

        public bool AddCoffeeToCart(Cart cf)
        {
            try
            {
                db.Insert(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }

        public bool EditCoffee(Coffee cf)
        {
            try
            {
                Console.WriteLine(cf.id + cf.name);
                 db.Update(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;
            }
        }
        public bool EditCart(Cart cf)
        {
            try
            {
                db.Update(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;
            }
        }

        public bool RemoveCoffee(Coffee cf)
        {
            try
            {
                db.Delete(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }
        public bool RemoveCart(Cart cf)
        {
            try
            {
                db.Delete(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }
        public bool RemoveFav(Favorite cf)
        {
            try
            {
                db.Delete(cf);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
                throw;

            }
        }
        public List<Cart> GetCartCoffee()
        {

            var coffee =  db.Table<Cart>().ToList();
            return coffee;
        }
        public List<Favorite> GetFavorite()
        {

            var coffee = db.Table<Favorite>().ToList();
            return coffee;
        }

        public List<Coffee> GetCoffee()
        {
            try
            {
                return db.Table<Coffee>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
                throw;

            }
        }

        //public List<Coffee> GetCoffeeById(int id)
        //{
        //    try
        //    {
        //        return db.Table<Coffee>().Where(o => o.id == id).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        return null;
        //        throw;

        //    }
        //}

    }
}
