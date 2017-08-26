using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TussController : Base                                 
    {                                                                               
        internal Tuss _Tuss { get; set; }                 
                                                                                    
        public TussController()                                        
        {                                                                           
            _Tuss = new Tuss();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTuss = _Tuss.GetAll().ToList(); 
            return View(collectionTuss);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TussDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TussDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Tuss = new Tuss();                    
                _Tuss.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

