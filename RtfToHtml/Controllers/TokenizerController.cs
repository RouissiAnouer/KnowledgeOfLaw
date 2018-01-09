using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Linq;
using System.IO;

namespace RtfToHtml.Controllers
{
    public class TokenizerController : Controller
    {
        
        // GET: Tokenizer
        public ActionResult Index()
        {
          
            return View();
           
        }
        

        [HttpPost]
        public JsonResult SaveFiles(string description)
        {
            string Message, fileName, actualFileName;
            string Type;
            float Taille;
            Message = fileName = actualFileName = string.Empty;
            var file = Request.Files[0];
            if (Request.Files != null)
            {
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file.FileName);
                file.SaveAs(path);
                
                string[] lines = System.IO.File.ReadAllLines(path);
                
                //foreach (string line in lines)
                //{
                var script = string.Join("\n", lines);
                string connectionString = "mongodb://localhost/27017";
                var Client = new MongoClient(connectionString);
                var DB = Client.GetDatabase("File");
                var collection = DB.GetCollection<BsonDocument>("Files");
                actualFileName = file.FileName;
                var tokenizer = new TextAnalysisTools.Tokenizer(new TextAnalysisTools.Analyseur.TextGrammer());
                foreach (var token in tokenizer.Tokenize(script))
                {
                    
                   
                    
                    
                    if (token.Type.ToString() != "WhiteSpace") {

                    
                    var documnt = new BsonDocument
            {
                        {"Fichier",actualFileName },
                        {token.Type.ToString(),script.Substring(token.StartIndex, token.Length) }
            };
                    collection.InsertOne(documnt);
                   
                }
                }
            }
            return Json(file, JsonRequestBehavior.AllowGet);
        }


    
       
    }
    
  



  

   
}