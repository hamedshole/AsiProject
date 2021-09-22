using Asi.Mobile.LocalData.Interface;
using Asi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Asi.Mobile.LocalData
{
    internal class Repository<TModel> : IRepository<TModel> where TModel: BaseModel
    {
        private List<TModel> Models;
        string localpath;
        public Repository(string path)
        {
            localpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)+"/"+path;
            if(File.Exists(localpath))
                Models = JsonConvert.DeserializeObject<List<TModel>>(localpath + "/" + path);
        }
        private void Save()
        {
            File.WriteAllText(localpath, JsonConvert.SerializeObject(Models));
        }
        public void Create(TModel model)
        {
            Models.Add(model);
            Save();
        }


        public void Delete(TModel model)
        {
            Models.Remove(model);
            Save();
        }

        public List<TModel> GetAll()
        {
            return Models;
        }

        public void Update(TModel model)
        {
            TModel model1 = Models.Find(x => x.Id == model.Id);
            model1 = model;
        }
    }
}
