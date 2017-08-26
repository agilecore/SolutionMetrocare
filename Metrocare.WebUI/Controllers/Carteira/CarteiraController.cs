using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class CarteiraController : Base                                 
    {                                                                               
        internal Carteira _Carteira { get; set; }                 
                                                                                    
        public CarteiraController()                                        
        {                                                                           
            _Carteira = new Carteira();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionCarteira = _Carteira.GetAll().ToList(); 
            return View(collectionCarteira);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new CarteiraDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(CarteiraDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Carteira = new Carteira();                    
                _Carteira.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

