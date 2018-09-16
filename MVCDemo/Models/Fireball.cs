using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;


namespace MVCDemo.Models
{
    public class Fireball<T>
    {

        public Fireball()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "entersecretkey",
                BasePath = "enterprojecturl",

            };

            this.client = new FirebaseClient(config);
            

        }
        IFirebaseClient client { get; set; }

        public string ID { get; set; }



        public T Get(string ID)
        {

            var response = client.Get($"{this.GetType().Name}/{ID}");
            T result = response.ResultAs<T>();
            return result;
        }

        public List<T> GetAll()
        {
            var results = new List<T>();
            var response = client.Get($"{this.GetType().Name}");

            IDictionary<string, T> data = response.ResultAs<IDictionary<string, T>>();


            if (data != null)
            {
                results = data.Values.ToList();
            }
            return results;
        }


        public T Insert()
        {
            this.ID = (new Random()).Next(1, 10000).ToString();


            var response = client.Set($"{this.GetType().Name}/{this.ID}", this);
            T result = response.ResultAs<T>();
            return result;
        }

        public string Insert2()
        {

            var response = client.Push($"{this.GetType().Name}", this);
            T result = response.ResultAs<T>();

            return response.Result.name; // this will return the auto generate id from firebase

        }

        public T Update()
        {

            var response = client.Set($"{this.GetType().Name}/{this.ID}", this);
            T result = response.ResultAs<T>();
            return result;

        }

        public bool Delete(string ID)
        {
            var response = client.Delete(this.GetType().Name + "/" + ID);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteAll()
        {
            var response = client.Delete(this.GetType().Name);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
